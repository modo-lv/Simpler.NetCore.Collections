using System;
using System.Collections.Generic;
using System.Linq;

namespace Simpler.NetCore.Collections {
  /// <summary>
  /// Shorthand methods for instantiating empty collections.
  /// </summary>
  /// <remarks>
  /// <c>E</c>: An empty <see cref="Enumerable"/>.<br />
  /// <c>L</c>: An empty <see cref="List{T}"/>.<br />
  /// <c>S</c>: An empty <see cref="HashSet{T}"/>.<br />
  /// <c>D</c>: An empty <see cref="Dictionary{T, T}"/>.<br />
  /// <c>*Str</c>: An empty collection of type <see cref="String"/>
  /// (both key and value in case of <see cref="Dictionary{TKey,TValue}" />).<br />
  /// </remarks>
  public static class Nil {
    /// <summary>
    /// Create an empty enumerable.
    /// </summary>
    public static IEnumerable<T> E<T>() => Enumerable.Empty<T>();

    /// <inheritdoc cref="E{T}"/>
    public static IEnumerable<String> EStr => E<String>();


    /// <summary>
    /// Create an empty <see cref="List{T}"/>.
    /// </summary>
    public static IList<T> L<T>() => new List<T>();

    /// <inheritdoc cref="L{T}"/>
    public static IList<String> LStr => L<String>();


    /// <summary>
    /// Create an empty <see cref="HashSet{T}"/>.
    /// </summary>
    public static ISet<T> S<T>() => new HashSet<T>();

    /// <inheritdoc cref="S{T}"/>
    public static ISet<String> SStr => S<String>();


    /// <summary>
    /// Create an empty <see cref="Dictionary{TKey,TValue}"/>.
    /// </summary>
    public static IDictionary<TKey, TVal> D<TKey, TVal>() => new Dictionary<TKey, TVal>();

    /// <inheritdoc cref="D{TKey,TVal}"/>
    public static IDictionary<T, T> D<T>() => D<T, T>();

    /// <inheritdoc cref="D{TKey,TVal}"/>
    public static IDictionary<String, TValue> DStr<TValue>() => D<String, TValue>();
  }
}
