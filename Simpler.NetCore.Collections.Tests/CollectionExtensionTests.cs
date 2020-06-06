using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

// ReSharper disable ArrangeTypeMemberModifiers

namespace Simpler.NetCore.Collections.Tests {
  public class CollectionExtensionTests {
    [Fact]
    void Get() {
      var i = new Dictionary<String, Int32> { { "a", 1 }};
      i.Get("a", 2).Should().Be(1);
      i.Get("b", 2).Should().Be(2);
      i.Get("c").Should().Be(0);
      
      var o = new Dictionary<String, Object> { { "a", "x" }};
      o.Get("a", "y").Should().Be("x");
      o.Get("b", "y").Should().Be("y");
      o.Get("c").Should().BeNull();
    }
    
    [Fact]
    void GetOrAdd() {
      var d = new Dictionary<String, Int32> { { "a", 1 } };
      d.GetOrAdd("a", 2).Should().Be(1);
      d.GetOrAdd("b", 2).Should().Be(2);
      d.GetOrAdd("b", 3).Should().Be(2);
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
      var noSep = new[] { "a", "b", "c" }.StringJoin();
      var withSep = new[] { "a", "b", "c" }.StringJoin(", ");

      Assert.Equal("abc", noSep);
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
