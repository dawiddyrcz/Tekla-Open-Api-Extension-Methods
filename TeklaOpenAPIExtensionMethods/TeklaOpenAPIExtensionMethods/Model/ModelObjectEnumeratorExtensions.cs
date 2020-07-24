using System;
using System.Collections.Generic;
using Tekla.Structures.Model;

namespace TeklaOpenAPIExtension
{
    public static class ModelObjectEnumeratorExtensions
    {
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
