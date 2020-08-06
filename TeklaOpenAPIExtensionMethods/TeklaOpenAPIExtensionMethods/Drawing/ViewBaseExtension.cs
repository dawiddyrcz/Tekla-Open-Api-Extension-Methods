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

/*
If you dont want to have codes which need reference to the Tekla.Structures.Drawing.dll then
open properties of your project, goto Build > Conditional compilation symbols and add symbol NOT_TSD
With NOT_TSD symbol the code bellow will not be included in your project
*/

#if !NOT_TSD

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
#endif