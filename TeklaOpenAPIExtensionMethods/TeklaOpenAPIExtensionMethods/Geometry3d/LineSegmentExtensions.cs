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

using Tekla.Structures.Geometry3d;

namespace TeklaOpenAPIExtension
{
    public static class LineSegmentExtensions
    {
        /// <summary>
        /// Returns center point of this line segment
        /// </summary>
        public static Point GetCenterPoint(this LineSegment lineSegment)
        {
            return lineSegment.Point1 + 0.5 * new Vector(lineSegment.Point2 - lineSegment.Point1);
        }

        /// <summary>
        /// Returns new line segment which are extended or shortened by extension value
        /// </summary>
        /// <param name="extension">Value to extend line segment</param>
        public static LineSegment GetExtended(this LineSegment lineSegment, double extension)
        {
            var direction = new Vector(lineSegment.Point2 - lineSegment.Point1).GetNormal();
            return new LineSegment(lineSegment.Point1 - direction * extension, lineSegment.Point2 + direction * extension);
        }

        /// <summary>
        /// Converts this line segment to line
        /// </summary>
        public static Line ToLine(this LineSegment lineSegment)
        {
            return new Line(lineSegment);
        }
    }
}
