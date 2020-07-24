using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T3D = Tekla.Structures.Geometry3d;

namespace TeklaOpenAPIExtension
{
    /// <summary>Contains static methods which are helpfull with finding intersection</summary>
    public static class Intersection2
    {
        /// <summary>Checks intersection between two line segments. Line segments are fragments of lines with start and end point.</summary>
        /// <param name="lineSegment1"></param>
        /// <param name="lineSegment2"></param>
        /// <param name="intersectionPoint">The point on the first or second line segment.</param>
        /// <returns>Return true if lines intersects and if point is on the linesegments.</returns>
        public static bool LineSegmentToLineSegment(T3D.LineSegment lineSegment1, T3D.LineSegment lineSegment2, out T3D.Point intersectionPoint)
        {
            intersectionPoint = new T3D.Point();
            if (lineSegment1 == null | lineSegment2 == null) return false;
            var line1 = new T3D.Line(lineSegment1);
            var line2 = new T3D.Line(lineSegment2);
            var intersectionLineSegment = T3D.Intersection.LineToLine(line1, line2);
            if (intersectionLineSegment == null) return false;

            intersectionPoint = T3D.Projection.PointToLine(intersectionLineSegment.Point1, line1);
            if (!IsThePointOnTheLineSegment(lineSegment1, intersectionPoint)) return false;

            intersectionPoint = T3D.Projection.PointToLine(intersectionLineSegment.Point1, line2);
            if (!IsThePointOnTheLineSegment(lineSegment2, intersectionPoint)) return false;

            return true;
        }

        /// <summary>Checks if the point is on the line segment. Line segment is the fragment of line in 3d with start point and end point. Method should be private but in public may be usefull</summary>
        /// <param name="lineSegment">The line segment</param>
        /// <param name="point">The point to check</param>
        /// <returns>Return true if point is on the line segment between start and end point. Otherwise return false.</returns>
        public static bool IsThePointOnTheLineSegment(T3D.LineSegment lineSegment, T3D.Point point)
        {
            if (T3D.Distance.PointToPoint(lineSegment.Point1, point) < 0.1) return true;
            if (T3D.Distance.PointToPoint(lineSegment.Point2, point) < 0.1) return true;

            var vector1 = new T3D.Vector(lineSegment.Point1 - point);
            var vector2 = new T3D.Vector(lineSegment.Point2 - point);

            return Math.Abs(vector1.GetAngleBetween(vector2) - Math.PI) < 0.001;
        }

        /// <summary>Gets list of line segments (fragment of lines with start and end points) and intersects all with all. </summary>
        /// <param name="lineSegmentList"></param>
        /// <returns>Returns Tekla.Structures.Drawing.PointList with intersected points</returns>
        public static Tekla.Structures.Drawing.PointList IntersectAllLineSegments(List<T3D.LineSegment> lineSegmentList)
        {
            var returnPointList = new Tekla.Structures.Drawing.PointList();

            for (int i = 0; i < lineSegmentList.Count - 1; i++)
            {
                var lineSegment1 = lineSegmentList[i];

                for (int j = i + 1; j < lineSegmentList.Count; j++)
                {
                    var lineSegment2 = lineSegmentList[j];

                    if (LineSegmentToLineSegment(lineSegment1, lineSegment2, out T3D.Point point))
                    {
                        returnPointList.Add(point);
                    }
                }
            }
            return returnPointList;
        }

        /// <summary>Gets array of line segments (fragment of lines with start and end points) and intersects all with all. </summary>
        /// <param name="lineSegmentList"></param>
        /// <returns>Returns Tekla.Structures.Drawing.PointList with intersected points</returns>
        public static Tekla.Structures.Drawing.PointList IntersectAllLineSegments(T3D.LineSegment[] lineSegmentList)
        {
            var returnPointList = new Tekla.Structures.Drawing.PointList();

            for (int i = 0; i < lineSegmentList.Length - 1; i++)
            {
                var lineSegment1 = lineSegmentList[i];

                for (int j = i + 1; j < lineSegmentList.Length; j++)
                {
                    var lineSegment2 = lineSegmentList[j];

                    if (LineSegmentToLineSegment(lineSegment1, lineSegment2, out T3D.Point point))
                    {
                        returnPointList.Add(point);
                    }
                }
            }
            return returnPointList;
        }
    }
}
