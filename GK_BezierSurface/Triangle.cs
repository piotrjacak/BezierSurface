using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace GK_BezierSurface
{
    public class Triangle
    {
        public Vertex vertex1 { get; set; }
        public Vertex vertex2 { get; set; }
        public Vertex vertex3 { get; set; }

        public List<List<Edge>> edgeTable { get; set; }

        public int minY { get; set; }
        public int maxY { get; set; }

        public float kd { get; set; }
        public float ks { get; set; }
        public int m { get; set; }

        public Vector3 fillColor { get; set; }
        public Vector3 lightColor { get; set; }
        public Vector3 lightDirection {  get; set; }

        public Bitmap texture {  get; set; }

        public float d00, d01, d11, denom;
        public Vector2 a, b, c;

        public bool isNormalMap { get; set; }


        public Triangle(Vertex v1, Vertex v2, Vertex v3, float kd, float ks, int m,
            SolidBrush fillColor, SolidBrush lightColor, Vector3 lightDirection)
        {
            vertex1 = v1;
            vertex2 = v2;
            vertex3 = v3;

            this.kd = kd;
            this.ks = ks;
            this.m = m;

            this.fillColor = BrushToVector3(fillColor);
            this.lightColor = BrushToVector3(lightColor);
            this.lightDirection = lightDirection;

            edgeTable = new List<List<Edge>>();
            texture = new Bitmap(1, 1);

            isNormalMap = false;

            SetUpEdgeTable();
            PrecomputeBarycentricData();
        }

        // Przygotowanie wartości do obliczania współrzędnych barycentrycznych
        public void PrecomputeBarycentricData()
        {
            a = new Vector2(vertex1.prevR.X, vertex1.prevR.Y);
            b = new Vector2(vertex2.prevR.X, vertex2.prevR.Y);
            c = new Vector2(vertex3.prevR.X, vertex3.prevR.Y);

            Vector2 v0v1 = b - a;
            Vector2 v0v2 = c - a;

            d00 = Vector2.Dot(v0v1, v0v1);
            d01 = Vector2.Dot(v0v1, v0v2);
            d11 = Vector2.Dot(v0v2, v0v2);

            denom = d00 * d11 - d01 * d01;
        }

        // Przygotowanie tablicy ET
        public void SetUpEdgeTable()
        {
            List<Edge> initalList = [new Edge(vertex1.prevR, vertex2.prevR),
                new Edge(vertex2.prevR, vertex3.prevR), new Edge(vertex3.prevR, vertex1.prevR)];

            this.minY = (int)Math.Floor(initalList.Min(e => e.ymin));
            this.maxY = (int)Math.Floor(initalList.Max(e => e.ymax));

            List<List<Edge>> ET = new List<List<Edge>>(new List<Edge>[maxY - minY + 1]);

            // Inicjalizacja kubełków
            for (int i = 0; i < ET.Count; i++)
            {
                ET[i] = new List<Edge>();
            }

            // Dodawanie krawędzi do kubełków w zależności od ymin
            foreach (var edge in initalList)
            {
                int bucketIndex = (int)(edge.ymin - minY);
                if (bucketIndex < 0 || bucketIndex >= ET.Count)
                    continue;
                ET[bucketIndex].Add(edge);
            }

            // Sortowanie każdego kubełka rosnąco po x
            foreach (var bucket in ET)
            {
                bucket.Sort((e1, e2) => e1.xmin.CompareTo(e2.xmin));
            }

            this.edgeTable = ET;
        }

        public void FillTriangle(Graphics g, DirectBitmap bitmap, bool isTexture)
        {
            // Włączony Antyaliasing
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Definicja AET
            List<Edge> activeEdgeTable = new List<Edge>();

            // Przejście scanlinii od minY do maxY
            for (int scanline = minY; scanline <= maxY; scanline++)
            {
                // Dodaj krawędzie z ET[y] do AET, jeśli ich ymin == y
                if (scanline - minY < edgeTable.Count && scanline - minY >= 0)
                {
                    foreach (var edge in edgeTable[scanline - minY])
                    {
                        activeEdgeTable.Add(new Edge(edge));
                    }
                }

                // Usuń krawędzie, których ymax == y
                activeEdgeTable.RemoveAll(e => (e.ymax < scanline) || Math.Abs(e.ymax - scanline) < 1e-4);

                // Sortuj AET według x
                activeEdgeTable.Sort((e1, e2) => e1.xmin.CompareTo(e2.xmin));

                // Wypełnij piksele pomiędzy parami przecięć
                for (int i = 0; i < activeEdgeTable.Count; i += 2)
                {
                    int l = 1;
                    if (activeEdgeTable.Count == 3) l = 2;

                    if (i + 1 < activeEdgeTable.Count)
                    {
                        float xStart = activeEdgeTable[i].xmin;
                        float xEnd = activeEdgeTable[i + l].xmin;
                        for (int x = (int)Math.Floor(xStart); x <= (int)Math.Ceiling(xEnd); x++)
                        {
                            PointF point = new PointF(x, scanline);

                            (byte br, byte bg, byte bb) = CalculatePointColor(point, isTexture);
                            Color col = Color.FromArgb(br, bg, bb);

                            int posX = (int)Math.Ceiling(point.X + (bitmap.Width / 2));
                            int posY = (int)Math.Ceiling(-point.Y + (bitmap.Height / 2));
                            if (posX >= 0 && posX < bitmap.Width && posY >= 0 && posY < bitmap.Height)
                            {
                                bitmap.SetPixel(posX, posY, col);
                            }
                        }
                    }
                }

                // Uaktualnij x dla każdej krawędzi w AET
                foreach (var edge in activeEdgeTable)
                {
                    edge.xmin += edge.inverseSlope;
                }
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            }
        }

        // Rysowanie trójkąta (krawędzie)
        public void DrawTriangle(Graphics g)
        {
            PointF p1 = new PointF(vertex1.prevR.X, vertex1.prevR.Y);
            PointF p2 = new PointF(vertex2.prevR.X, vertex2.prevR.Y);
            PointF p3 = new PointF(vertex3.prevR.X, vertex3.prevR.Y);

            g.DrawLine(Pens.Gray, p1, p2);
            g.DrawLine(Pens.Gray, p2, p3);
            g.DrawLine(Pens.Gray, p3, p1);
        }


        // Wyznaczenie współrzędnych barycentrycznych
        public Vector3 CalculateBarycentricCoordinates(PointF point)
        {
            Vector2 p = new Vector2(point.X, point.Y);
            Vector2 v0p = p - a;

            float d20 = Vector2.Dot(v0p, b - a);
            float d21 = Vector2.Dot(v0p, c - a);

            float v = (d11 * d20 - d01 * d21) / denom;
            float w = (d00 * d21 - d01 * d20) / denom;
            float u = 1.0f - v - w;

            return new Vector3(u, v, w);
        }


        // Wyznaczenie koloru piksela
        public (byte r, byte g, byte b) CalculatePointColor(PointF point, bool isTexture)
        {
            // Wyznaczenie współrzędnych barycentrycznych
            Vector3 bary = CalculateBarycentricCoordinates(point);

            // Interpolacja wektorów normalnych
            Vector3 interpolatedNormal = Vector3.Normalize(
                bary.X * this.vertex1.vectorN +
                bary.Y * this.vertex2.vectorN +
                bary.Z * this.vertex3.vectorN
            );

            // Wyznaczenie koloru obiektu
            Vector3 objectColor = BrushToVector3(new SolidBrush(Color.White));
            if (isTexture)
            {
                Color localColor;
                float u = bary.X * this.vertex1.u +
                    bary.Y * this.vertex2.u +
                    bary.Z * this.vertex3.u;
                float v = bary.X * this.vertex1.v +
                    bary.Y * this.vertex2.v +
                    bary.Z * this.vertex3.v;

                int x = (int)Math.Floor(v * (texture.Width - 1));
                int y = (int)Math.Floor(u * (texture.Height - 1));
                if (x >= 0 && x < texture.Width && y >= 0 && y < texture.Height)
                {
                    localColor = texture.GetPixel(x, y);
                    SolidBrush brush = new SolidBrush(localColor);
                    objectColor = BrushToVector3(brush);
                }

                // Przypadek, gdy isNormalMap
                if (isNormalMap)
                {
                    // Interpolacja wektorów Pu
                    Vector3 interpolatedVectorPu = Vector3.Normalize(
                        bary.X * this.vertex1.vectorPu +
                        bary.Y * this.vertex2.vectorPu +
                        bary.Z * this.vertex3.vectorPu
                    );

                    // Interpolacja wektorów Pv
                    Vector3 interpolatedVectorPv = Vector3.Normalize(
                        bary.X * this.vertex1.vectorPv +
                        bary.Y * this.vertex2.vectorPv +
                        bary.Z * this.vertex3.vectorPv
                    );

                    Matrix4x4 matrix = new Matrix4x4(
                        interpolatedVectorPu.X, interpolatedVectorPv.X, interpolatedNormal.X, 0,
                        interpolatedVectorPu.Y, interpolatedVectorPv.Y, interpolatedNormal.Y, 0,
                        interpolatedVectorPu.Z, interpolatedVectorPv.Z, interpolatedNormal.Z, 0,
                        0, 0, 0, 1
                    );

                    Vector4 ocExtended = new Vector4(objectColor, 0);
                    Vector4 result = Vector4.Transform(ocExtended, matrix);
                    objectColor = new Vector3(result.X, result.Y, result.Z);
                }
            }
            else
            {
                objectColor = fillColor;
            }


            // Interpolacja punktu
            Vector3 vertex = (
                bary.X * this.vertex1.prevR + 
                bary.Y * this.vertex2.prevR +
                bary.Z * this.vertex3.prevR
            );

            // Wyznaczenie wektorów L i V
            lightDirection = new Vector3(vertex.X - lightDirection.X, vertex.Y - lightDirection.Y, vertex.Z - lightDirection.Z);
            Vector3 L = Vector3.Normalize(lightDirection);
            Vector3 V = new Vector3(0, 0, 1);

            // Wyznaczenie składowej rozproszonej
            float cosNL = Math.Max(0, Vector3.Dot(interpolatedNormal, L));
            Vector3 diffuse = kd * lightColor * objectColor * cosNL;

            // Wyznaczenie składowej zwierciadlanej
            Vector3 R = Vector3.Normalize(2 * cosNL * interpolatedNormal - L);
            float cosVR = Math.Max(0, Vector3.Dot(V, R));
            Vector3 specular = ks * lightColor * objectColor * (float)Math.Pow(cosVR, m);


            Vector3 color = diffuse + specular;
            byte r = (byte)Math.Clamp((int)(color.X * 255), 0, 255);
            byte g = (byte)Math.Clamp((int)(color.Y * 255), 0, 255);
            byte b = (byte)Math.Clamp((int)(color.Z * 255), 0, 255);

            return (r, g, b);
        }


        // Konwertuje SolidBrush na Vector3
        public static Vector3 BrushToVector3(SolidBrush brush)
        {
            Color color = brush.Color;
            return new Vector3(
                color.R / 255f,
                color.G / 255f,
                color.B / 255f
            );
        }
    }
}
