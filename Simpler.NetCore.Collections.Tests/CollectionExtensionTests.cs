using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

// ReSharper disable ArrangeTypeMemberModifiers

namespace Simpler.NetCore.Collections.Tests {
  public class CollectionExtensionTests {
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
  }
}