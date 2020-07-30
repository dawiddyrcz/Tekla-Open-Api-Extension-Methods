using System.Collections.Generic;
using Tekla.Structures.Model;

namespace TeklaOpenAPIExtension
{
    public static class AssemblyExtensions
    {
        /// <summary>Get parts from this assembly. If assembly has no main part then return empty list</summary>
        public static List<Part> GetParts(this Assembly assembly, bool includeMainPart = true)
        {
            var mainPart = assembly.GetMainPart() as Part;

            if (mainPart != null)
            {
                var assemblyParts = new List<Part>();

                if (includeMainPart) assemblyParts.Add(mainPart);

                foreach (var secondary in assembly.GetSecondaries())
                {
                    if (secondary is Part part)
                    {
                        assemblyParts.Add(part);
                    }
                }

                return assemblyParts;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"WARNING: Assembly {assembly.Identifier.ID} has no main part");
                return new List<Part>();
            }
        }
    }
}
