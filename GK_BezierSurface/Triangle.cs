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

        //private Vector3 L = Vector3.Normalize(new Vector3(1, 1, 1)); // Kierunek światła
        //private Vector3 V = new Vector3(0, 0, 1); // Wektor widzenia
        //private Vector3 IL = new Vector3(1, 1, 1); // Kolor światła (biały)
        //private Vector3 IO = new Vector3(0.7f, 0.7f, 1.0f); // Kolor obiektu (jasny niebieski)

        //private float kd = 0.8f; // Składowa rozproszona
        //private float ks = 0.5f; // Składowa zwierciadlana
        //private int m = 50; // Współczynnik zwierciadlności


        public Triangle(Vertex v1, Vertex v2, Vertex v3)
        {
            vertex1 = v1;
            vertex2 = v2;
            vertex3 = v3;

            edgeTable = new List<List<Edge>>();
            SetUpEdgeTable();

        }

        // Przygotowanie tablicy ET
        public void SetUpEdgeTable()
        {
            List<Edge> initalList = [new Edge(vertex1.prevR, vertex2.prevR),
                new Edge(vertex2.prevR, vertex3.prevR), new Edge(vertex3.prevR, vertex1.prevR)];

            int minY = (int)Math.Floor(initalList.Min(e => e.ymin));
            int maxY = (int)Math.Ceiling(initalList.Max(e => e.ymin));

            List<List<Edge>> ET = new List<List<Edge>>(new List<Edge>[maxY + 1]);

            // Inicjalizacja kubełków
            for (int i = 0; i < ET.Count; i++)
            {
                ET[i] = new List<Edge>();
            }

            // Dodawanie krawędzi do kubełków w zależności od ymin
            foreach (var edge in initalList)
            {
                int bucketIndex = (int)edge.ymin;
                ET[bucketIndex].Add(edge);
            }

            // Sortowanie każdego kubełka rosnąco po x
            int k = 0;
            Console.WriteLine("Triangle");
            foreach (var bucket in ET)
            {
                bucket.Sort((e1, e2) => e1.xmin.CompareTo(e2.xmin));
                for (int i = 0; i < bucket.Count; i++)
                {
                    Console.WriteLine($"Bucket {k}: ymax: {bucket[i].ymax}, ymin: {bucket[i].ymin}, x: {bucket[i].xmin}, i = {i}");
                }
                k++;
            }

            this.edgeTable = ET;
        }

        public void FillTriangle(Graphics g)
        {
            // Znalezienie najmniejszej wartości indeksu, gdzie ET[y] jest niepuste
            int y = 0;
            for (int i = 0; i < edgeTable.Count; i++)
            {
                if (edgeTable[i].Count > 0)
                {
                    y = i;
                    break;
                }
            }

            // Definicja AET
            List<Edge> AET = new List<Edge>();
            float level = edgeTable[y][0].ymin;

            Console.WriteLine("\nFill Triangle");
            Console.WriteLine($"Level first: {level}");

            while (y < edgeTable.Count && (edgeTable[y].Count > 0 || AET.Count > 0))
            {
                // Przenieś krawędzie z ET[y] do AET, jeśli ich ymin == y
                foreach (Edge edge in edgeTable[y])
                {
                    AET.Add(new Edge(edge));
                }


                // Sortuj AET według x
                AET = AET.OrderBy(edge => edge.xmin).ToList();

                // Wypełnij piksele pomiędzy parami przecięć
                for (int i = 0; i < AET.Count - 1; i += 2)
                {
                    float xStart = AET[i].xmin;
                    float xEnd = AET[i + 1].xmin;

                    PointF start = new PointF(xStart, level);
                    PointF end = new PointF(xEnd, level);

                    // Symulowane wypełnianie pikseli (możesz zastąpić tą część kodem do rysowania pikseli)
                    g.DrawLine(Pens.LightBlue, start, end);
                }

                // Usuń krawędzie, których ymax == y
                //AET.RemoveAll(edge => edge.ymax == y);

                // Przejdź do następnej scan-linii
                y++;
                level++;
                Console.WriteLine($"Y = {y}, level = {level}");
                // Uaktualnij x dla każdej krawędzi w AET
                foreach (var edge in AET)
                {
                    edge.xmin += (1 / edge.inverseSlope);
                    //Console.WriteLine($"Edge: xmin: {edge.xmin}, ymin:");
                }
            }
            Console.WriteLine($"Level end: {level}");

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
    }
}
