using NUnit.Framework;

using AdventOfCode.Solvers;

namespace AdventOfCode.Tests {
  public class Day04SolverTests {

    [TestCase("5", new string[] { "111111-111115" })]
    public void TestPartOne(string expected, string[] input) {
      Solver s = new Day04Solver();
      string result = s.SolvePartOne(input);
      Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("2", new string[] { "111443-111446" })]
    public void TestPartTwo(string expected, string[] input) {
      Solver s = new Day04Solver();
      string result = s.SolvePartTwo(input);
      Assert.That(result, Is.EqualTo(expected));
    }
  }
}
