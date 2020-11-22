using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

// ReSharper disable ArrangeTypeMemberModifiers

namespace Simpler.NetCore.Collections.Tests {
  public class CollectionExtensionTests {
    [Fact]
    void GetOr() {
      var i = new Dictionary<String, Int32> { { "a", 1 } };
      i.GetOr("a", 2).Should().Be(1);
      i.GetOr("b", 2).Should().Be(2);
      i.GetOr("c", default).Should().Be(0);

      var o = new Dictionary<String, Object?> { { "a", "x" }, { "b", null } };
      o.GetOr("a", "y").Should().Be("x");
      o.GetOr("b", "y").Should().Be("y");
      o.GetOr("b", "y", acceptNulls: true).Should().BeNull();
      o.GetOr("c", default!).Should().BeNull();
    }

    [Fact]
    void GetOrAdd() {
      var d = new Dictionary<String, Int32?> { { "a", 1 }, { "b", null }, { "c", null } };
      d.GetOrAdd("a", 0).Should().Be(1);
      d.GetOrAdd("b", 2).Should().Be(2);
      d.GetOrAdd("c", 3, acceptNulls: true).Should().BeNull();
    }

    [Fact]
    void IsOneOf() {
      var no = "x".IsOneOf(new List<String> { "a", "b", "c" });
      var yes = "b".IsOneOf("a", "b", "c");
      no.Should().BeFalse();
      yes.Should().BeTrue();
    }

    [Fact]
    void StringJoin() {
      var noSep = new[] { 1, 23, 42 }.StringJoin();
      var withSep = new[] { "a", "b", "c" }.StringJoin(", ");

      Assert.Equal("12342", noSep);
      Assert.Equal("a, b, c", withSep);
    }

    [Fact]
    void ToDictionary() {
      var input = new List<KeyValuePair<String, Int32>> { new KeyValuePair<String, Int32>("a", 1) };
      var output = input.ToDictionary();

      output["a"].Should().Be(1);
    }
  }
}
