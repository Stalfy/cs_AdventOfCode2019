using NUnit.Framework;

using System.Drawing;
using System.Collections.Generic;

using AdventOfCode.Solvers;

namespace AdventOfCode.Tests {
  public class Day15SolverTests {

    public void TestPartOne(string expected, string[] input) {
      Solver s = new Day15Solver();
      string result = s.SolvePartOne(input);
      Assert.That(result, Is.EqualTo(expected));
    }

    public void TestPartTwo(string expected, string[] input) {
      Solver s = new Day15Solver();
      string result = s.SolvePartTwo(input);
      Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void TestFillWithOxygen() {
      Day15Solver s = new Day15Solver();
      Dictionary<Point, long> inDict = new Dictionary<Point, long>();

      inDict[new Point(0, 0)] = 1;
      inDict[new Point(1, 0)] = 1;
      inDict[new Point(2, 0)] = 1;
      inDict[new Point(0, 1)] = 1;
      inDict[new Point(1, 1)] = 0;
      inDict[new Point(2, 1)] = 1;
      inDict[new Point(0, 2)] = 1;
      inDict[new Point(1, 2)] = 2;
      inDict[new Point(2, 2)] = 1;

      Dictionary<Point, int> outDict = s.FillWithOxygen(inDict);
      Assert.That(outDict[new Point(0, 0)], Is.EqualTo(3));
      Assert.That(outDict[new Point(1, 0)], Is.EqualTo(4));
      Assert.That(outDict[new Point(2, 0)], Is.EqualTo(3));
      Assert.That(outDict[new Point(0, 1)], Is.EqualTo(2));
      Assert.That(outDict.ContainsKey(new Point(1, 1)), Is.EqualTo(false));
      Assert.That(outDict[new Point(2, 1)], Is.EqualTo(2));
      Assert.That(outDict[new Point(0, 2)], Is.EqualTo(1));
      Assert.That(outDict[new Point(1, 2)], Is.EqualTo(0));
      Assert.That(outDict[new Point(2, 2)], Is.EqualTo(1));
    }
  }
}
