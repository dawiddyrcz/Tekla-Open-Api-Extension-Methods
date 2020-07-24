using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Drawing;

namespace TeklaOpenAPIExtension
{
    public static class DrawingEnumeratorExtension
    {
        public static List<Drawing> ToList(this DrawingEnumerator enumerator)
        {
            var output = new List<Drawing>(enumerator.GetSize());

            while (enumerator.MoveNext())
            {
                output.Add(enumerator.Current);
            }

            return output;
        }

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
