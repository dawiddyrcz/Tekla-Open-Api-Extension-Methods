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

using System.Collections.Generic;
using Tekla.Structures.Drawing;

namespace TeklaOpenAPIExtension
{
    public static class DrawingEnumeratorExtension
    {
        /// <summary>Add items from the enumerator to the System.Collections.Generic.List</summary>
        public static List<Drawing> ToList(this DrawingEnumerator enumerator)
        {
            var output = new List<Drawing>(enumerator.GetSize());

            while (enumerator.MoveNext())
            {
                output.Add(enumerator.Current);
            }

            return output;
        }

        /// <summary>Add items from the enumerator to the System.Collections.Generic.List. if (enumerator.Current is T t) output.Add(t);</summary>
        public static List<T> ToList<T>(this DrawingEnumerator enumerator) where T : Drawing
        {
            var output = new List<T>(enumerator.GetSize());

            while (enumerator.MoveNext())
            {
                if (enumerator.Current is T t)
                    output.Add(t);
            }

            return output;
        }
    }
}
#endif