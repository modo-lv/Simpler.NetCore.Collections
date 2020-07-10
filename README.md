# Simpler.NetCore.Collections

![](https://github.com/modo-lv/Simpler.NetCore.Collections/workflows/Tests/badge.svg)

## Extension methods

### `.ForEach(Action)`

A fluent alternative to `foreach (var element in collection) { action(element); }`.

```cs
new [] { 1, 2, 3 }.ForEach(n => Console.WriteLine(n));
```


### `.GetOr(key, fallback, acceptNulls)`

Retrieve a value from a dictionary, or a fallback value if `key` is not present or is null (depending on `acceptNulls`).

```cs
var i = new Dictionary<String, Int32> { { "a", 1 } };
i.GetOr("a", 2)       // 1
i.GetOr("b", 2)       // 2
i.GetOr("c", default) // 0

var o = new Dictionary<String, Object?> { { "a", "x" }, { "b", null } };
o.GetOr("a", "y")                    // "x"
o.GetOr("b", "y")                    // "y"
o.GetOr("b", "y", acceptNulls: true) // null
o.GetOr("c", default!)               // null
```


### `.GetOrAdd(key, value, acceptNulls)`

Retrieve a value from a dictionary, adding it if `key` is not present or is null (depending on `acceptNulls`).

```cs
var d = new Dictionary<String, Int32?> { { "a", 1 }, { "b", null }, { "c", null } };
d.GetOrAdd("a", 0)                    // 1
d.GetOrAdd("b", 2)                    // 2
d.GetOrAdd("c", 3, acceptNulls: true) // null
```

### `.IsOneOf`

A fluent alternative to `Enumerable.Contains`.

**Usage:**

```cs
"x".IsOneOf(new List<String> { "a", "b", "c" }); // false
"b".IsOneOf("a", "b", "c");                      // true
```

### `.StringJoin`

A fluent alternative to `String.Join`.

**Usage:**

```cs
new []{"a","b","c"}.StringJoin();     // "abc"
new []{"a","b","c"}.StringJoin(", "); // "a, b, c"
```

### `.ToDictionary`

Parameter-less conversion of any collection of key-value pairs to a dictionary. 

```cs
new List<KeyValuePair<String, Int32>>{
  new KeyValuePair<String, Int32>("a", 1)
}.toDictionary(); // { "a": 1 }
```

## `Nil`

Contains shorthand methods and properties for instantiating common collections.

##### Methods

* `.E()` creates an empty Enumerable.
* `.C()` creates an empty Collection.
* `.L()` creates an empty List.
* `.S()` creates an empty HashSet.
* `.D()` creates an empty Dictionary.

##### Properties

**`*Str`** properties for each type instantiate the corresponding collection of `String`s. For `Dictionary` it's `DStr<TValue>`, which creates a dictionary of `String` keys and `TValue` values.
