using System.Collections.Generic;

using NUnit.Framework;

using AdventOfCode.Solvers.Day11;

namespace AdventOfCode.Tests {
  public class PositionEqualityComparerTests {

    [Test]
    public void TestAdd() {
      Dictionary<Position, long> dict = 
        new Dictionary<Position, long>(new PositionEqualityComparer());

      Position posA = new Position(0, 0);
      Position posB = new Position(0, 0);

      dict[posA] = 3;

      Assert.That(dict.ContainsKey(posB), Is.EqualTo(true));
      Assert.That(dict[posB], Is.EqualTo(3));
    }

    public void TestUpdate() {
      Dictionary<Position, long> dict = 
        new Dictionary<Position, long>(new PositionEqualityComparer());

      Position posA = new Position(0, 0);
      Position posB = new Position(0, 0);

      dict[posA] = 3;
      dict[posB] = 2;

      Assert.That(dict[posA], Is.EqualTo(2));
    }
  }
}
