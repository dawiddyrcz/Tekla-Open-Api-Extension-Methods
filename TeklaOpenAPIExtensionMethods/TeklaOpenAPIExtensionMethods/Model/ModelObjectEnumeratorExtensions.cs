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
using System;
using System.Collections;
using System.Collections.Generic;
using Tekla.Structures.Model;
using TeklaOpenAPIExtension.Collections;

namespace TeklaOpenAPIExtension
{
    public static class ModelObjectEnumeratorExtensions
    {
	    /// <inheritdoc cref="Collections.IEnumeratorExtensions.ToReadOnlyCollection{TDrawing}"/>
		public static IReadOnlyCollection<TModelObject> ToReadOnlyCollection<TModelObject>(this ModelObjectEnumerator enumerator) where TModelObject : Tekla.Structures.Model.ModelObject
        {
            return ((IEnumerator)enumerator).ToReadOnlyCollection<TModelObject>();
        }

        public static List<ModelObject> ToList(this ModelObjectEnumerator enumerator, bool selectInstances = false)
        {
            enumerator.SelectInstances = selectInstances;
            var output = new List<ModelObject>(enumerator.GetSize());

            while (enumerator.MoveNext())
            {
                output.Add(enumerator.Current);
            }

            return output;
        }

        public static List<T> ToList<T>(this ModelObjectEnumerator enumerator, bool selectInstances = false) where T : ModelObject
        {
            enumerator.SelectInstances = selectInstances;
            var output = new List<T>(enumerator.GetSize());

            while (enumerator.MoveNext())
            {
                if (enumerator.Current is T t)
                    output.Add(t);
            }

            return output;
        }

        public static Dictionary<Guid, ModelObject> ToDictionaryGuid(this ModelObjectEnumerator enumerator, bool selectInstances = false)
        {
            enumerator.SelectInstances = selectInstances;
            var output = new Dictionary<Guid, ModelObject>(enumerator.GetSize());

            while (enumerator.MoveNext())
            {
                var modelObject = enumerator.Current;

                if (!output.ContainsKey(modelObject.Identifier.GUID))
                    output.Add(modelObject.Identifier.GUID, enumerator.Current);
            }
            return output;
        }

        public static Dictionary<Guid, T> ToDictionaryGuid<T>(this ModelObjectEnumerator enumerator, bool selectInstances = false) where T : ModelObject
        {
            enumerator.SelectInstances = selectInstances;
            var output = new Dictionary<Guid, T>(enumerator.GetSize());

            while (enumerator.MoveNext())
            {
                var modelObject = enumerator.Current;

                if (modelObject is T t)
                {
                    if (!output.ContainsKey(modelObject.Identifier.GUID))
                        output.Add(modelObject.Identifier.GUID, t);
                }
            }
            return output;
        }

        public static Dictionary<int, ModelObject> ToDictionaryId(this ModelObjectEnumerator enumerator, bool selectInstances = false)
        {
            enumerator.SelectInstances = selectInstances;
            var output = new Dictionary<int, ModelObject>(enumerator.GetSize());

            while (enumerator.MoveNext())
            {
                var modelObject = enumerator.Current;

                if (!output.ContainsKey(modelObject.Identifier.ID))
                    output.Add(modelObject.Identifier.ID, enumerator.Current);
            }
            return output;
        }

        public static Dictionary<int, T> ToDictionaryId<T>(this ModelObjectEnumerator enumerator, bool selectInstances = false) where T : ModelObject
        {
            enumerator.SelectInstances = selectInstances;
            var output = new Dictionary<int, T>(enumerator.GetSize());

            while (enumerator.MoveNext())
            {
                var modelObject = enumerator.Current;

                if (modelObject is T t)
                {
                    if (!output.ContainsKey(modelObject.Identifier.ID))
                        output.Add(modelObject.Identifier.ID, t);
                }
            }
            return output;
        }

    }
}
