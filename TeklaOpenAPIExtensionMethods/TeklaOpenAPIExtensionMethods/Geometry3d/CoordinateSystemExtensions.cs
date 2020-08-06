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
using Tekla.Structures.Model;

namespace TeklaOpenAPIExtension
{
    public static class CoordinateSystemExtensions
    {
        public static Vector GetAxisZ(this CoordinateSystem cs)
        {
            return cs.AxisX.Cross(cs.AxisY);
        }

        public static TransformationPlane ToTransformationPlane(this CoordinateSystem cs)
        {
            return new TransformationPlane(cs);
        }

        public static Matrix MatrixToGlobal(this CoordinateSystem cs)
        {
            return MatrixFactory.FromCoordinateSystem(cs);
        }

        public static Matrix MatrixToLocal(this CoordinateSystem cs)
        {
            return MatrixFactory.ToCoordinateSystem(cs);
        }

        public static GeometricPlane ToGeometricPlane(this CoordinateSystem cs)
        {
            return new GeometricPlane(cs);
        }
    }
}
