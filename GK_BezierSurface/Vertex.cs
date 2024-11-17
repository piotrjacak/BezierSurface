using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace GK_BezierSurface
{
    public class Vertex
    {
        public Vector3 prevR { get; set; }  // Punkt przed obrotem
        public Vector3 afterR { get; set; }  // Punkt po obrocie
        public float u { get; set; }  // U parameter
        public float v { get; set; }  // V parameter

        public Vector3 vectorPu { get; set; } // wektor styczny Pu
        public Vector3 vectorPv { get; set; } // wektor styczny Pv
        public Vector3 vectorN { get; set; } // wektor normalny N

        public Vertex[,] controlPoints { get; set; }// punkty kontrolne płaszczyzny


        public Vertex()
        {
            this.controlPoints = new Vertex[4, 4];
        }

        public Vertex(Vector3 prevR)
        {
            this.prevR = prevR;
            this.controlPoints = new Vertex[4, 4];
        }

        public void UpdateVectors()
        {
            CalculateVectorPu();
            CalculateVectorPv();

            this.vectorN = Vector3.Cross(vectorPu, vectorPv);
        }


        // Funkcja pomocnicza wyznaczająca wektor dla parametrów u i v
        public void CalculateBezierPoint()
        {
            Vector3 point = Vector3.Zero;
            for (int i = 0; i < 4; i++)
            {
                float bernsteinU = Bernstein(i, 3, u);
                for (int j = 0; j < 4; j++)
                {
                    float bernsteinV = Bernstein(j, 3, v);
                    point += controlPoints[i, j].prevR * (bernsteinU * bernsteinV);
                }
            }

            this.prevR = point;
            UpdateVectors();
        }

        // Funkcja pomocnicza wyznaczająca wektor styczny Pu dla parametrów u i v
        public void CalculateVectorPu()
        {
            Vector3 point = Vector3.Zero;
            for (int i = 0; i < 3; i++)
            {
                float bernsteinU = Bernstein(i, 2, u);
                for (int j = 0; j < 4; j++)
                {
                    float bernsteinV = Bernstein(j, 3, v);
                    point += (controlPoints[i + 1, j].prevR - controlPoints[i, j].prevR) * (bernsteinU * bernsteinV);
                }
            }

            this.vectorPu = 3 * point;
        }

        // Funkcja pomocnicza wyznaczająca wektor styczny Pv dla parametrów u i v
        public void CalculateVectorPv()
        {
            Vector3 point = Vector3.Zero;
            for (int i = 0; i < 4; i++)
            {
                float bernsteinU = Bernstein(i, 3, u);
                for (int j = 0; j < 3; j++)
                {
                    float bernsteinV = Bernstein(j, 2, v);
                    point += (controlPoints[i, j + 1].prevR - controlPoints[i, j].prevR) * (bernsteinU * bernsteinV);
                }
            }

            this.vectorPv = 3 * point;
        }


        // Funkcja pomocnicza do obliczenia symbolu Newtona
        public int BinomialCoefficient(int n, int k)
        {
            if (k > n) return 0;
            if (k == 0 || k == n) return 1;

            int coefficient = 1;
            for (int i = 1; i <= k; i++)
            {
                coefficient = coefficient * (n - i + 1) / i;
            }
            return coefficient;
        }

        // Funkcja pomocnicza do obliczenia wartosci wielomianu Bernsteina
        public float Bernstein(int i, int n, float t)
        {
            int binomial = BinomialCoefficient(n, i);

            return binomial * (float)Math.Pow(t, i) * (float)Math.Pow(1 - t, n - i);
        }




        public void RotateOX(float angle)
        {
            // Konwersja ze stopni na radiany
            float angleRadian = MathF.PI * angle / 180.0f;

            Matrix4x4 rotationMatrix = Matrix4x4.CreateRotationX(angleRadian);
            prevR = Vector3.Transform(prevR, rotationMatrix);
        }

        public void RotateOZ(int angle)
        {
            // Konwersja ze stopni na radiany
            float angleRadian = MathF.PI * angle / 180.0f;

            Matrix4x4 rotationMatrix = Matrix4x4.CreateRotationZ(angleRadian);
            prevR = Vector3.Transform(prevR, rotationMatrix);
        }
    }
}
