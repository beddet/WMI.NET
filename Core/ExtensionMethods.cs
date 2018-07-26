using System;
using System.Collections.Generic;

namespace Core
{
	public static class ExtensionMethods
	{
		/// <summary>
		/// Determines whether the specified source contains the key, if the key was found the out TValue value parameter holds the value
		/// </summary>
		/// <typeparam name="TKey">The type of the key.</typeparam>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="source">The source.</param>
		/// <param name="key">The key.</param>
		/// <param name="value">The value.</param>
		/// <returns>
		///   <c>true</c> if the specified source contains key; otherwise, <c>false</c>.
		/// </returns>
		public static bool ContainsKey<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, out TValue value)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}

			if (source.ContainsKey(key))
			{
				value = source[key];
				return true;
			}
			value = default(TValue);
			return false;
		}
	}
}