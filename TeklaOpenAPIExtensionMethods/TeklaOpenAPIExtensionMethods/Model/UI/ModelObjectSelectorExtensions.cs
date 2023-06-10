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
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model.UI;
using ModelObject = Tekla.Structures.Model.ModelObject;
using ModelObjectSelector = Tekla.Structures.Model.UI.ModelObjectSelector;

namespace TeklaOpenAPIExtension.Model.UI
{
	public static class ModelObjectSelectorExtensions
	{
		/// <summary>
		/// Returns a <see cref="IReadOnlyCollection{TModelObject}"/> of the given view's visible model objects that collide with the given geometrical bounding box.
		/// </summary>
		/// <typeparam name="TModelObject">Type of the model objects to return.</typeparam>
		/// <param name="selector">The model object selector to get objects from.</param>
		/// <param name="bounds">The bounding box.</param>
		/// <param name="view">The view to get the objects from.</param>
		/// <returns>A <see cref="IReadOnlyCollection{TModelObject}"/> of the visible model objects colliding with the given bounding box.</returns>
		/// <remarks>Note that this method uses approximate bounding boxes and thus is NOT EXACT, and may return objects not necessarily colliding with the given box but only being somewhere near to it.</remarks>
		public static IReadOnlyCollection<TModelObject> GetObjectsByBoundingBox<TModelObject>(this ModelObjectSelector selector, AABB bounds, View view) where TModelObject : ModelObject
		{
			return selector.GetObjectsByBoundingBox(bounds.MinPoint, bounds.MaxPoint, view).ToReadOnlyCollection<TModelObject>();
		}

		/// <summary>
		/// Returns a <see cref="IReadOnlyCollection{TModelObject}"/> of the given view's visible model objects that collide with the given geometrical bounding box.
		/// </summary>
		/// <typeparam name="TModelObject">Type of the model objects to return.</typeparam>
		/// <param name="selector">The model object selector to get objects from.</param>
		/// <param name="minPoint">The minimum point of the bounding box.</param>
		/// <param name="maxPoint">The maximum point of the bounding box.</param>
		/// <param name="view">The view to get the objects from.</param>
		/// <returns>A <see cref="IReadOnlyCollection{TModelObject}"/> of the visible model objects colliding with the given bounding box.</returns>
		/// <remarks>Note that this method uses approximate bounding boxes and thus is NOT EXACT, and may return objects not necessarily colliding with the given box but only being somewhere near to it.</remarks>
		public static IReadOnlyCollection<TModelObject> GetObjectsByBoundingBox<TModelObject>(this ModelObjectSelector selector, Point minPoint, Point maxPoint, View view) where TModelObject : ModelObject
		{
			return selector.GetObjectsByBoundingBox(minPoint, maxPoint, view).ToReadOnlyCollection<TModelObject>();
		}

		/// <summary>
		/// Returns a <see cref="IReadOnlyCollection{TModelObject}"/> of all the selected model objects in the model view.
		/// </summary>
		/// <typeparam name="TModelObject">Type of the model objects to return.</typeparam>
		/// <param name="selector">The model object selector to get objects from.</param>
		/// <returns>A <see cref="IReadOnlyCollection{TModelObject}"/> of all the selected model objects.</returns>
		public static IReadOnlyCollection<TModelObject> GetSelected<TModelObject>(this ModelObjectSelector selector) where TModelObject : ModelObject
		{
			return selector.GetSelectedObjects().ToReadOnlyCollection<TModelObject>();
		}
	}
}
