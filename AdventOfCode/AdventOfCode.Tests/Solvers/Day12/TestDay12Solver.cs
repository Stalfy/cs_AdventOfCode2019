using NUnit.Framework;

using AdventOfCode.Solvers;

namespace AdventOfCode.Tests {
  public class Day12SolverTests {

    [TestCase("179", 10, new string[] {
      "<x=-1, y=0, z=2>",
      "<x=2, y=-10, z=-7>",
      "<x=4, y=-8, z=8>",
      "<x=3, y=5, z=-1>"
    })]
    [TestCase("1940", 100, new string[] {
      "<x=-8, y=-10, z=0>",
      "<x=5, y=5, z=10>",
      "<x=2, y=-7, z=3>",
      "<x=9, y=-8, z=-3>"
    })]
    public void TestPartOne(string expected, int steps, string[] input) {
      Day12Solver s = new Day12Solver();
      string result = s.SolvePartOne(input, steps);
      Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("2772", new string[] {
      "<x=-1, y=0, z=2>",
      "<x=2, y=-10, z=-7>",
      "<x=4, y=-8, z=8>",
      "<x=3, y=5, z=-1>"
    })]
    [TestCase("4686774924", new string[] {
      "<x=-8, y=-10, z=0>",
      "<x=5, y=5, z=10>",
      "<x=2, y=-7, z=3>",
      "<x=9, y=-8, z=-3>"
    })]
    public void TestPartTwo(string expected, string[] input) {
      Solver s = new Day12Solver();
      string result = s.SolvePartTwo(input);
      Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void TestLCM() {
      Day12Solver s = new Day12Solver();
      Assert.That(s.LCM(21, 6), Is.EqualTo(42));
      Assert.That(s.LCM(6, 21), Is.EqualTo(42));
    }

    [Test]
    public void TestGCD() {
      Day12Solver s = new Day12Solver();
      Assert.That(s.GCD(5, 15), Is.EqualTo(5));
      Assert.That(s.GCD(15, 5), Is.EqualTo(5));
    }
  }
}
