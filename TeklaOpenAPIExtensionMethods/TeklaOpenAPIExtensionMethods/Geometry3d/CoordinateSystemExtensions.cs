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
