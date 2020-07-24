using System;
using System.Collections.Generic;
using Tekla.Structures.Drawing;
using Tekla.Structures.Geometry3d;

namespace TeklaOpenAPIExtension
{
    public static class ViewBaseExtension
    {
        public static List<T> GetObjects<T>(this ViewBase viewBase) where T : DrawingObject
        {
            return viewBase.GetObjects(new Type[] { typeof(T) }).ToList<T>();
        }

        public static List<T> GetAllObjects<T>(this ViewBase viewBase) where T: DrawingObject
        {
            return viewBase.GetAllObjects(typeof(T)).ToList<T>();
        }

        public static Point Get_Bottom_Left_Corner(this ViewBase viewBase)
        {
            return viewBase.Origin + viewBase.FrameOrigin;
        }

        public static Point Get_Bottom_Right_Corner(this ViewBase viewBase)
        {
            var output = viewBase.Origin + viewBase.FrameOrigin;
            output.X = viewBase.Width;
            return output;
        }

        public static Point Get_Top_Right_Corner(this ViewBase viewBase)
        {
            var output = viewBase.Origin + viewBase.FrameOrigin;
            output.X = viewBase.Width;
            output.Y = viewBase.Height;
            return output;
        }

        public static Point Get_Top_Left_Corner(this ViewBase viewBase)
        {
            var output = viewBase.Origin + viewBase.FrameOrigin;
            output.Y = viewBase.Height;
            return output;
        }
    }
}
