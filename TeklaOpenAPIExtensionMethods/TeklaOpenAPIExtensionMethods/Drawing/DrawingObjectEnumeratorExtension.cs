using System.Collections.Generic;
using Tekla.Structures.Drawing;

namespace TeklaOpenAPIExtension
{
    public static class DrawingObjectEnumeratorExtension
    {
        public static List<DrawingObject> ToList(this DrawingObjectEnumerator enumerator)
        {
            var output = new List<DrawingObject>(enumerator.GetSize());

            while (enumerator.MoveNext())
            {
                output.Add(enumerator.Current);
            }

            return output;
        }

        public static List<T> ToList<T>(this DrawingObjectEnumerator enumerator) where T : DrawingObject
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
