using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Tesselation
{
    class TesselationAlgo
    {
        List<Point> points;
        List<Triangle> triangles;

        public TesselationAlgo(List<Point> inpoints)
        {
            points = inpoints;
            triangles = new List<Triangle>();
        }

        /* Very simple ear clipping algorithm */
        public void EarTrimming(Graphics canvas)
        {
            Pen p = new Pen(Color.Blue);
            Pen red = new Pen(Color.Red);
            bool canTriangulate = true;

            while (canTriangulate)
            {
                canTriangulate = false;
                for (int i = 1; i < points.Count - 1; i++)
                {
                    if (IsEar(i) && !IsInside(i))
                    {
                        triangles.Add(new Triangle(points[i - 1], points[i], points[i + 1]));
                        points.RemoveAt(i);
                        canTriangulate = true;
                    }
                }
            }
        }

        /* Check is there any point inside the triangle */
        private bool IsInside(int index)
        {

            for (int i = 0; i < points.Count; i++)
            {
                if (i >= index-1 && i <=index+1) continue;
                if(Triangle.IsInside(points[index-1],points[index],points[index+1],points[i])) return true;
            }

            return false;
        }

        /* Check the point is an ear? */
        private bool IsEar(int index)
        {
            return Triangle.Area(points[index - 1], points[index], points[index + 1]) < 0.0 ? false : true;
        }

        /* Draw the triangles */
        public void DrawTriangles(Graphics canvas)
        {
            foreach (Triangle tri in triangles)
            {
                tri.Draw(canvas);
            }
        }
    }
}
