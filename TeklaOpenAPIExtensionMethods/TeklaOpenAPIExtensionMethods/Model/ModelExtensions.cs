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

using System;
using Tekla.Structures.Geometry3d;
using ts = Tekla.Structures;
using tsm = Tekla.Structures.Model;

namespace TeklaOpenAPIExtension
{
    public static class ModelExtensions
    {
        public static string ModelPath(this tsm.Model model)
        {
            return model.GetInfo().ModelPath;
        }

        public static string AttributesPath(this tsm.Model model)
        {
            return System.IO.Path.Combine(model.GetInfo().ModelPath, "attributes");
        }

        public static TModelObject Select<TModelObject>(this tsm.Model model, ts.Identifier identifier) where TModelObject : tsm.ModelObject
        {
            return model.SelectModelObject(identifier) as TModelObject;
        }

        public static bool TrySelect<TModelObject>(this tsm.Model model, ts.Identifier identifier, out TModelObject modelObject) where TModelObject : tsm.ModelObject
        {
	        modelObject = model.Select<TModelObject>(identifier);
	        return modelObject != null;
        }

        public static TModelObject Select<TModelObject>(this tsm.Model model, Guid guid) where TModelObject : tsm.ModelObject
        {
	        var identifier = model.GetIdentifierByGUID(guid.ToString());
	        return model.SelectModelObject(identifier) as TModelObject;
        }

        public static bool TrySelect<TModelObject>(this tsm.Model model, Guid guid, out TModelObject modelObject) where TModelObject : tsm.ModelObject
        {
	        modelObject = model.Select<TModelObject>(guid);
	        return modelObject != null;
        }

        /// <summary>
        /// Calculates global vector Z in current transformation plane (current local coordinate)
        /// </summary>
        public static Vector GetCurrentGlobalVectorZ(this tsm.Model model)
        {
            var p0 = new Point();
            var p2 = new Point(0, 0, 1000);

            var matrixToLocal = model.GetWorkPlaneHandler().GetCurrentTransformationPlane().TransformationMatrixToLocal;
            var p0_local = matrixToLocal.Transform(p0);
            var p2_local = matrixToLocal.Transform(p2);
            return new Vector(p2_local - p0_local).GetNormal();
        }
	}
}
