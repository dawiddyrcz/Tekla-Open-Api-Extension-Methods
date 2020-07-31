using System;
using System.Collections.Generic;
using Tekla.Structures.Drawing;
using Tekla.Structures.Geometry3d;

namespace TeklaOpenAPIExtension
{
    public static class ViewBaseExtension
    {
        /// <summary>Call viewBase.GetObjects(new Type[] { typeof(T) }) and add to list</summary>
        /// <typeparam name="T">DrawingObject</typeparam>
        /// <returns>System.Collections.Generic.List</returns>
        public static List<T> GetObjects<T>(this ViewBase viewBase) where T : DrawingObject
        {
            return viewBase.GetObjects(new Type[] { typeof(T) }).ToList<T>();
        }

        /// <summary>Call viewBase.GetAllObjects(new Type[] { typeof(T) }) and add to list</summary>
        /// <typeparam name="T">DrawingObject</typeparam>
        /// <returns>System.Collections.Generic.List</returns>
        public static List<T> GetAllObjects<T>(this ViewBase viewBase) where T: DrawingObject
        {
            return viewBase.GetAllObjects(typeof(T)).ToList<T>();
        }

        /// <summary>Gets point from the Bottom Left corner of the view frame</summary>
        public static Point Get_Bottom_Left_Corner(this ViewBase viewBase)
        {
            return viewBase.Origin + viewBase.FrameOrigin;
        }

        /// <summary>Gets point from the Bottom Right corner of the view frame</summary>
        public static Point Get_Bottom_Right_Corner(this ViewBase viewBase)
        {
            var output = viewBase.Origin + viewBase.FrameOrigin;
            output.X += viewBase.Width;
            return output;
        }

        /// <summary>Gets point from the Top Right corner of the view frame</summary>
        public static Point Get_Top_Right_Corner(this ViewBase viewBase)
        {
            var output = viewBase.Origin + viewBase.FrameOrigin;
            output.X += viewBase.Width;
            output.Y += viewBase.Height;
            return output;
        }

        /// <summary>Gets point from the Top Left corner of the view frame</summary>
        public static Point Get_Top_Left_Corner(this ViewBase viewBase)
        {
            var output = viewBase.Origin + viewBase.FrameOrigin;
            output.Y += viewBase.Height;
            return output;
        }
    }
}
