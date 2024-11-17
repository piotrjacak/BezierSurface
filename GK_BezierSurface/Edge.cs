using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GK_BezierSurface
{
    public class Edge
    {
        public float ymax { get; set; }
        public float ymin { get; set; }
        public float xmin {  get; set; }
        public float inverseSlope { get; set; }

        public Edge(Vector3 p1, Vector3 p2)
        {
            if (p1.Y < p2.Y)
            {
                ymax = p2.Y;
                ymin = p1.Y;
                xmin = p1.X;
            }
            else
            {
                ymax = p1.Y;
                ymin = p2.Y;
                xmin = p2.X;
            }

            if (Math.Abs(p1.Y - p2.Y) < float.Epsilon)
            {
                inverseSlope = 0;
            }
            else
            {
                inverseSlope = (p2.X - p1.X) / (p2.Y - p1.Y);
            }
        }

        // Konstruktor do głębokiej kopii
        public Edge(Edge edge)
        {
            this.ymax = edge.ymax;
            this.ymin = edge.ymin;
            this.xmin = edge.xmin;
            this.inverseSlope = edge.inverseSlope;
        }
    }
}
