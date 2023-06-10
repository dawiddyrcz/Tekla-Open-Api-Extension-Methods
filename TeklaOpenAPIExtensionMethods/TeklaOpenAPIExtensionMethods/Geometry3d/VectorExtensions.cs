/*
MIT License

Copyright (c) 2020 Dawid Dyrcz

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
    public static class VectorExtensions
    {
        public static Vector Add(this Vector vector, Vector vectorToAdd)
        {
            var output = new Vector(vector);
            output.X += vectorToAdd.X;
            output.Y += vectorToAdd.Y;
            output.Z += vectorToAdd.Z;
            return output;
        }

        public static Vector Add(this Vector vector, Point vectorToAdd)
        {
            var output = new Vector(vector);
            output.X += vectorToAdd.X;
            output.Y += vectorToAdd.Y;
            output.Z += vectorToAdd.Z;
            return output;
        }

        public static Vector Subtract(this Vector vector, Vector vectorToSubtract)
        {
            var output = new Vector(vector);
            output.X -= vectorToSubtract.X;
            output.Y -= vectorToSubtract.Y;
            output.Z -= vectorToSubtract.Z;
            return output;
        }

        public static Vector Subtract(this Vector vector, Point vectorToSubtract)
        {
            var output = new Vector(vector);
            output.X -= vectorToSubtract.X;
            output.Y -= vectorToSubtract.Y;
            output.Z -= vectorToSubtract.Z;
            return output;
        }

        public static double GetSignedAngle(Vector v1, Vector v2, Vector referenceVector)
        {
            var angle = v1.GetAngleBetween(v2);
            if (v1.Cross(v2).Dot(referenceVector) < 0)
                angle = -1.0 * angle;
            return angle;
        }
    }
}
