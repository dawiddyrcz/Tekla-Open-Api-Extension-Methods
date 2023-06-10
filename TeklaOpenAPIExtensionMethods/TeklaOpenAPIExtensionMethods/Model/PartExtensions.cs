/*
MIT License

Copyright (c) 2023 Dawid Dyrcz

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System.Collections.Generic;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;

namespace TeklaOpenAPIExtension
{
    public static class PartExtensions
    {
        /// <summary>
        /// Gets this part cetner line as list of poins not arraylist
        /// </summary>
        public static List<Point> GetCenterLinePoints(this Part part, bool withCutsFittings)
        {
            var centerLineArrayList = part.GetCenterLine(withCutsFittings);
            var output = new List<Point>();

            foreach (var item in centerLineArrayList)
            {
                if (item is Point)
                    output.Add(item as Point);
            }
            
            return output;
        }

        /// <summary>
        /// Gets this part cetner line as list of linesegments
        /// </summary>
        public static List<LineSegment> GetCenterLineSegments(this Part part, bool withCutsFittings)
        {
            var points = part.GetCenterLinePoints(withCutsFittings);
            var output = new List<LineSegment>();

            for (int i = 1; i < points.Count; i++)
            {
                var ls = new LineSegment(points[i - 1], points[i]);
                output.Add(ls);
            }

            return output;
        }

        /// <summary>
        /// Gets this part reference line as list of poins not arraylist
        /// </summary>
        public static List<Point> GetReferenceLinePoints(this Part part, bool withCutsFittings)
        {
            var referenceLineArrayList = part.GetReferenceLine(withCutsFittings);
            var output = new List<Point>();

            foreach (var item in referenceLineArrayList)
            {
                if (item is Point)
                    output.Add(item as Point);
            }

            return output;
        }

        /// <summary>
        /// Gets this part reference line as list of linesegments
        /// </summary>
        public static List<LineSegment> GetReferenceLineSegments(this Part part, bool withCutsFittings)
        {
            var points = part.GetReferenceLinePoints(withCutsFittings);
            var output = new List<LineSegment>();

            for (int i = 1; i < points.Count; i++)
            {
                var ls = new LineSegment(points[i - 1], points[i]);
                output.Add(ls);
            }

            return output;
        }
    }
}
