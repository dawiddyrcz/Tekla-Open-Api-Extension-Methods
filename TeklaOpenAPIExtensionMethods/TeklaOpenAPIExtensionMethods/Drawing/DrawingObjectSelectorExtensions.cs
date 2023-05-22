/*
MIT License

Copyright (c) 2022 Dawid Dyrcz

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

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tekla.Structures.Drawing;
using Tekla.Structures.Drawing.UI;

namespace TeklaOpenAPIExtension
{
    public static class DrawingObjectSelectorExtensions
	{
		/// <summary>
		/// Gets the selected objects in the drawing of type <typeparamref name="TDrawingObject"/>.
		/// </summary>
		/// <typeparam name="TDrawingObject">Type of returned drawing objects.</typeparam>
		/// <param name="selector">Selector to find drawing objects.</param>
		/// <returns>A <see cref="IReadOnlyCollection{TDrawingObject}"/> of the selected objects in the drawing.</returns>
		public static IReadOnlyCollection<TDrawingObject> GetSelected<TDrawingObject>(this DrawingObjectSelector selector) where TDrawingObject : DrawingObject
	    {
		    return selector.GetSelected().ToReadOnlyCollection<TDrawingObject>();
	    }

        public static void SelectObjects(this DrawingObjectSelector selector, IEnumerable<DrawingObject> drawingObjects, bool extendSelection = false)
        {
            var arList = new ArrayList(drawingObjects.Count());

            foreach (var drObject in drawingObjects)
                arList.Add(drObject);

            selector.SelectObjects(arList, extendSelection);
        }
    }
}

#endif