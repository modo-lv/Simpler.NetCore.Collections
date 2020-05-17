using System;
using System.Collections.Generic;
using System.Linq;

namespace Simpler.NetCore.Collections {
  /// <summary>
  /// Extension methods for working with collections.
  /// </summary>
  public static class CollectionExtensions {
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
  }
}