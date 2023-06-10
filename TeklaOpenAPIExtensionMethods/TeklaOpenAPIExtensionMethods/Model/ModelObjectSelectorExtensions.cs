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
using Tekla.Structures.Filtering;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;

namespace TeklaOpenAPIExtension.Model
{
	public static class ModelObjectSelectorExtensions
	{
		/// <summary>
		/// Returns a <see cref="IReadOnlyCollection{TModelObject}"/> of all the model objects in the current model with the given base type.
		/// </summary>
		/// <typeparam name="TModelObject">Type of the model objects to return.</typeparam>
		/// <param name="selector">The model object selector to get objects from.</param>
		/// <returns>A <see cref="IReadOnlyCollection{TModelObject}"/> of all the model objects with the given types.</returns>
		public static IReadOnlyCollection<TModelObject> GetAllObjects<TModelObject>(this ModelObjectSelector selector) where TModelObject : ModelObject
		{
			return selector.GetAllObjectsWithType(new[] { typeof(TModelObject) }).ToReadOnlyCollection<TModelObject>();
		}

		/// <summary>
		/// Returns a <see cref="IReadOnlyCollection{TModelObject}"/> of all the model objects in the current model with the given type. 
		/// </summary>
		/// <typeparam name="TModelObject">Type of the model objects to return.</typeparam>
		/// <param name="selector">The model object selector to get objects from.</param>
		/// <param name="objectEnum">The type of the objects to return.</param>
		/// <returns>A <see cref="IReadOnlyCollection{TModelObject}"/> of all the model objects with the given type.</returns>
		public static IReadOnlyCollection<TModelObject> GetAllObjects<TModelObject>(this ModelObjectSelector selector, ModelObject.ModelObjectEnum objectEnum) where TModelObject : ModelObject
		{
			return selector.GetAllObjectsWithType(objectEnum).ToReadOnlyCollection<TModelObject>();
		}

		/// <summary>
		/// Returns a <see cref="IReadOnlyCollection{TModelObject}"/> of the model objects in the current model with the given type and selected by the filter.
		/// </summary>
		/// <typeparam name="TModelObject">Type of the model objects to return.</typeparam>
		/// <param name="selector">The model object selector to get objects from.</param>
		/// <param name="objectEnum">The type of the objects to return.</param>
		/// <param name="filterName">The name of an existing selection filter to apply.</param>
		/// <returns>A <see cref="IReadOnlyCollection{TModelObject}"/> of the model objects with the given type and selected by the filter.</returns>
		public static IReadOnlyCollection<TModelObject> GetFilteredObjects<TModelObject>(this ModelObjectSelector selector, ModelObject.ModelObjectEnum objectEnum, string filterName) where TModelObject : ModelObject
		{
			return selector.GetFilteredObjectsWithType(objectEnum, filterName).ToReadOnlyCollection<TModelObject>();
		}

		/// <summary>
		/// Returns a <see cref="IReadOnlyCollection{TModelObject}"/> of the model objects of type <typeparamref name="TModelObject"/> in the current model selected by the given selection filter definition.
		/// </summary>
		/// <typeparam name="TModelObject">Type of the model objects to return.</typeparam>
		/// <param name="selector">The model object selector to get objects from.</param>
		/// <param name="expression">The definition of a selection filter to apply.</param>
		/// <returns>A <see cref="IReadOnlyCollection{TModelObject}"/> of the objects selected by the filter.</returns>
		public static IReadOnlyCollection<TModelObject> GetObjects<TModelObject>(this ModelObjectSelector selector, FilterExpression expression) where TModelObject : ModelObject
		{
			return selector.GetObjectsByFilter(expression).ToReadOnlyCollection<TModelObject>();
		}

		/// <summary>
		/// Returns a <see cref="IReadOnlyCollection{TModelObject}"/> of the model objects of type <typeparamref name="TModelObject"/> in the current model selected by the given selection filter.
		/// </summary>
		/// <typeparam name="TModelObject">Type of the model objects to return.</typeparam>
		/// <param name="selector">The model object selector to get objects from.</param>
		/// <param name="filterName">The name of an existing selection filter to apply.</param>
		/// <returns>A <see cref="IReadOnlyCollection{TModelObject}"/> of the objects selected by the filter.</returns>
		public static IReadOnlyCollection<TModelObject> GetObjects<TModelObject>(this ModelObjectSelector selector, string filterName) where TModelObject : ModelObject
		{
			return selector.GetObjectsByFilterName(filterName).ToReadOnlyCollection<TModelObject>();
		}

		/// <summary>
		/// Returns a <see cref="IReadOnlyCollection{TModelObject}"/> of the model objects in the current model colliding with the given geometrical bounding box.
		/// </summary>
		/// <typeparam name="TModelObject">Type of the model objects to return.</typeparam>
		/// <param name="selector">The model object selector to get objects from.</param>
		/// <param name="minPoint">The minimum point of the bounding box.</param>
		/// <param name="maxPoint">The maximum point of the bounding box.</param>
		/// <returns>A <see cref="IReadOnlyCollection{TModelObject}"/> of the model objects colliding with the given bounding box.</returns>
		/// <remarks>Note that this method uses approximate bounding boxes and thus is NOT EXACT, and may return objects not necessarily colliding with the given box but only being somewhere near to it.</remarks>
		public static IReadOnlyCollection<TModelObject> GetObjectsByBoundingBox<TModelObject>(this ModelObjectSelector selector, Point minPoint, Point maxPoint) where TModelObject : ModelObject
		{
			return selector.GetObjectsByBoundingBox(minPoint, maxPoint).ToReadOnlyCollection<TModelObject>();
		}

		/// <summary>
		/// Returns a <see cref="IReadOnlyCollection{TModelObject}"/> of the model objects in the current model colliding with the given geometrical bounding box.
		/// </summary>
		/// <typeparam name="TModelObject">Type of the model objects to return.</typeparam>
		/// <param name="selector">The model object selector to get objects from.</param>
		/// <param name="bounds">The bounding box to check model objects against.</param>
		/// <returns>A <see cref="IReadOnlyCollection{TModelObject}"/> of the model objects colliding with the given bounding box.</returns>
		/// <remarks>Note that this method uses approximate bounding boxes and thus is NOT EXACT, and may return objects not necessarily colliding with the given box but only being somewhere near to it.</remarks>
		public static IReadOnlyCollection<TModelObject> GetObjectsByBoundingBox<TModelObject>(this ModelObjectSelector selector, AABB bounds) where TModelObject : ModelObject
		{
			return selector.GetObjectsByBoundingBox(bounds.MinPoint, bounds.MaxPoint).ToReadOnlyCollection<TModelObject>();
		}
	}
}
