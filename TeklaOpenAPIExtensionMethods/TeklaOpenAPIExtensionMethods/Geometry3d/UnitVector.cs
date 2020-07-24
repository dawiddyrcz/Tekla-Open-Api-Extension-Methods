using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Geometry3d;

namespace TeklaOpenAPIExtension
{
    public static class UnitVector
    {
        public static Vector X { get { return new Vector(1, 0, 0); } }
        public static Vector Y { get { return new Vector(0, 1, 0); } }
        public static Vector Z { get { return new Vector(0, 0, 1); } }
    }
}
