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


    /// <inheritdoc cref="string.Join(string,IEnumerable{string})"/>
    public static String StringJoin(this IEnumerable<Object> values, String separator = "") {
      return String.Join(separator, values);
    }


    /// <inheritdoc cref="Enumerable.Contains{TSource}(IEnumerable{TSource},TSource)"/>
    public static Boolean IsOneOf<TSource>(this TSource value, IEnumerable<TSource> source) =>
      source.Contains(value);

    /// <inheritdoc cref="Enumerable.Contains{TSource}(IEnumerable{TSource},TSource)"/>
    public static Boolean IsOneOf<TSource>(this TSource value, params TSource[] sources) =>
      sources.Contains(value);


    /// <summary>
    /// Parameter-less conversion of any collection of key-value pairs to a dictionary. 
    /// </summary>
    public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
      this IEnumerable<KeyValuePair<TKey, TValue>> pairs
    ) =>
      pairs.ToDictionary(_ => _.Key, _ => _.Value);
  }
}
