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
