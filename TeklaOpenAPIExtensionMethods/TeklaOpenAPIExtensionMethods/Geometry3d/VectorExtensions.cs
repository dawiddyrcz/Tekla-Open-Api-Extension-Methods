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
    }
}
