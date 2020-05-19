# Simpler.NetCore.Collections

## Extension methods

### `.ForEach(Action)`

A fluent alternative to `foreach (var element in collection) { action(element); }`.

```cs
new [] { 1, 2, 3 }.ForEach(n => Console.WriteLine(n));
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

## `Nil`

Contains shorthand methods and properties for instantiating common collections.

##### Methods

* `.E()` creates an empty Enumerable.
* `.L()` Creates an empty List.
* `.S()` Creates an empty HashSet.
* `.D()` Creates an empty Dictionary.

##### Properties

**`*Str`** properties for each type instantiate the corresponding collection of `String`s. For `Dictionary` it's `DStr<TValue>`, which creates a dictionary of `String` keys and `TValue` values.