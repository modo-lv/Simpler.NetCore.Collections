using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

// ReSharper disable UnusedMember.Global

namespace Simpler.NetCore.Collections {
  /// <summary>
  /// Extension methods for working with collections.
  /// </summary>
  public static class CollectionExtensions {
    /// <summary>
    /// Run an action on each element in a collection.
    /// </summary>
    /// <param name="values">Collection of elements.</param>
    /// <param name="action">Action to execute.</param>
    /// <typeparam name="T">Element type</typeparam>
    public static void ForEach<T>(this IEnumerable<T> values, Action<T> action) {
      foreach (var value in values)
        action(value);
    }


    /// <summary>
    /// Retrieve a value from a dictionary, or a fallback value if
    /// <paramref name="key"/> is not present or is <c>null</c> (depending on <paramref name="acceptNulls"/>).
    /// </summary>
    /// <param name="dictionary">Dictionary to look in.</param>
    /// <param name="key">Key of the element to retrieve</param>
    /// <param name="fallback">
    ///   Default value to return if the key is not present in the <paramref name="dictionary"/>.
    /// </param>
    /// <param name="acceptNulls">Treat <c>null</c> values as present in the dictionary?</param>
    /// <typeparam name="TKey">Dictionary key type.</typeparam>
    /// <typeparam name="TValue">Dictionary value type.</typeparam>
    /// <returns>Dictionary element at <paramref name="key"/> or <paramref name="fallback"/> if not found.</returns>
    public static TValue GetOr<TKey, TValue>
      (this IDictionary<TKey, TValue> dictionary, TKey key, TValue fallback, Boolean acceptNulls = false)
      =>
        dictionary.ContainsKey(key)
          ? !acceptNulls && dictionary[key] == null ? fallback : dictionary[key]
          : fallback;


    /// <summary>
    /// Retrieve a value from a dictionary, adding it if <paramref name="key"/> is not present
    /// or is <c>null</c> (depending on <paramref name="acceptNulls"/>).
    /// </summary>
    /// <param name="dic">Dictionary to check/update.</param>
    /// <param name="key">Key to check/add.</param>
    /// <param name="value">Value to add if <paramref name="key"/> is not present in the dictionary.</param>
    /// <param name="acceptNulls">Treat <c>null</c> values as present in the dictionary?</param>
    /// <returns>The value at the given key if it exists, or the new <paramref name="value"/> if not.</returns>
    public static TValue GetOrAdd<TKey, TValue>
      (this IDictionary<TKey, TValue> dic, TKey key, TValue value, Boolean acceptNulls = false) 
    {
      if (!dic.ContainsKey(key) || dic[key] == null && !acceptNulls)
        dic[key] = value;
      return dic[key];
    }


    /// <inheritdoc cref="Enumerable.Contains{TSource}(IEnumerable{TSource},TSource)"/>
    public static Boolean IsOneOf<TSource>(this TSource value, IEnumerable<TSource> source) =>
      source.Contains(value);

    /// <inheritdoc cref="Enumerable.Contains{TSource}(IEnumerable{TSource},TSource)"/>
    public static Boolean IsOneOf<TSource>(this TSource value, params TSource[] sources) =>
      sources.Contains(value);


    /// <inheritdoc cref="string.Join(string,IEnumerable{string})"/>
    public static String StringJoin(this IEnumerable<Object> values, String separator = "") {
      return String.Join(separator, values);
    }


    /// <summary>
    /// Parameter-less conversion of any collection of key-value pairs to a dictionary. 
    /// </summary>
    public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
      this IEnumerable<KeyValuePair<TKey, TValue>> pairs
    ) =>
      pairs.ToDictionary(_ => _.Key, _ => _.Value);
  }
}
