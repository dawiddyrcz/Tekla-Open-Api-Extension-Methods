using Tekla.Structures.Geometry3d;

namespace TeklaOpenAPIExtension.Geometry3d
{
    public static class MatrixExtensions
    {
        public static Vector TransformVector(this Matrix matrix, Vector vector)
        {
            var p0 = new Vector(0,0,0);
            var p0Transformed = matrix.Transform(p0);
            var vectorPointTransformed = matrix.Transform(vector);

            return new Vector(vectorPointTransformed - p0Transformed);
        }
    }
}
