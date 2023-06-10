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

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TeklaOpenAPIExtension.Collections
{
	public static class IEnumeratorExtensions
	{
		/// <summary>
		/// Moves over elements within <paramref name="enumerator"/> and returns a <see cref="IReadOnlyCollection{TReturn}"/> of all elements of type <typeparamref name="TReturn"/>.
		/// </summary>
		/// <typeparam name="TReturn">The type of element to return.</typeparam>
		/// <param name="enumerator">A generic enumerator of elements.</param>
		/// <returns>A <see cref="IReadOnlyCollection{TReturn}"/> of typed elements from <paramref name="enumerator"/>.</returns>
		/// <remarks><see cref="IEnumerator.Reset"/> will not be called on <paramref name="enumerator"/> during the execution of <see cref="ToEnumerable{TReturn}"/>.</remarks>
		public static IReadOnlyCollection<TReturn> ToReadOnlyCollection<TReturn>(this IEnumerator enumerator)
		{
			return enumerator.ToEnumerable<TReturn>().ToArray();
		}

		/// <summary>
		/// Moves over elements within <paramref name="enumerator"/> and returns all elements of type <typeparamref name="TReturn"/>.
		/// </summary>
		/// <typeparam name="TReturn">The type of element to return.</typeparam>
		/// <param name="enumerator">A generic enumerator of elements.</param>
		/// <returns>All elements of type <typeparamref name="TReturn"/> from <paramref name="enumerator"/>.</returns>
		/// <remarks><see cref="IEnumerator.Reset"/> will not be called on <paramref name="enumerator"/> during the execution of <see cref="ToEnumerable{TReturn}"/>.</remarks>
		private static IEnumerable<TReturn> ToEnumerable<TReturn>(this IEnumerator enumerator)
		{
			while (enumerator.MoveNext())
				if (enumerator.Current is TReturn typedCurrent)
					yield return typedCurrent;
		}
	}
}
