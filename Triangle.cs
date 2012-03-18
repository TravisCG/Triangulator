using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Tesselation
{
    class Triangle
    {
        Point[] vertex;

        public Triangle(Point a, Point b, Point c)
        {
            vertex = new Point[3];
            vertex[0] = a;
            vertex[1] = b;
            vertex[2] = c;
        }

        public Triangle(Point[] v)
        {
            vertex = new Point[3];
            v.CopyTo(vertex, 0);
        }

        public void Draw(Graphics Canvas)
        {
            Pen pen = new Pen(Color.Red);
            Brush brush = pen.Brush;
            Canvas.FillPolygon(brush, vertex);
        }

        /* Area of the triangle. This formula can be use to detemine the
         * orientation of the triangle
         * Based on http://softsurfer.com/Archive/algorithm_0101/algorithm_0101.htm
         */
        public static double Area(Point a, Point b, Point c)
        {
            return ((b.X - a.X) * (c.Y - a.Y) - (c.X - a.X) * (b.Y - a.Y));
        }

        /* Check that the given point test is inside the triangle
         * Based on http://www.gamedev.net/topic/295943-is-this-a-better-point-in-triangle-test-2d/
         */
        public static Boolean IsInside(Point v1, Point v2, Point v3, Point test)
        {
            bool a, b, c;

            a = Area(test, v1, v2) < 0.0 ? true : false;
            b = Area(test, v2, v3) < 0.0 ? true : false;
            c = Area(test, v3, v1) < 0.0 ? true : false;
            return( (a == b) && (a == c) );
        }
    }
}
