# Simpler.NetCore.Collections

## Extension methods

### `IsOneOf`

A fluent alternative to `Enumerable.Contains`.

**Usage:**

```cs
"x".IsOneOf(new List<String> { "a", "b", "c" }); // false
"b".IsOneOf("a", "b", "c");                      // true
``` 

### `StringJoin`

A fluent alternative to `String.Join`.

**Usage:**

```cs
new []{"a","b","c"}.StringJoin();     // "abc"
new []{"a","b","c"}.StringJoin(", "); // "a, b, c"
``` 

