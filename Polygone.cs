using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Tesselation
{
    class Polygone
    {
        private List<Point> points;

        public Polygone(){
            points = new List<Point>();
        }

        /*
         * Add points to the list using coordinates
         */
        public void AddPoint(int x, int y){
            points.Add(new Point(x, y));
        }

        /*
         * Add points to the list using Point object
         */
        public void AddPoint(Point newpoint)
        {
            points.Add(newpoint);
        }

        /*
         * Enumerator to access to the points
         */
        public IEnumerable<Point> GetEnumerator()
        {
            foreach(Point p in points){
                yield return p;
            }
        }

        /*
         * If the class does not contain any elements its return true
         */
        public bool Zero()
        {
            return points.Count > 0 ? false : true;
        }

        public Point Last()
        {
            return points.Last<Point>();
        }

        /*
         * This method is for easy polygone redraw
         */
        public Point[] GetPoints()
        {
            Point[] result = new Point[points.Count];
            points.CopyTo(result);
            return (result);
        }

        /*
         * This method is for tesselation objects
         */
        public List<Point> GetList()
        {
            return points;
        }

        /*
         * Close the poligone
         */
        public void Close()
        {
            points.Add(points[0]);
        }

        /*
         * Remove elements
         */
        public void Clear()
        {
            points.Clear();
        }
    }
}
