using NUnit.Framework;

using AdventOfCode.Solvers;

namespace AdventOfCode.Tests {
  public class Day04SolverTests {

    public void TestPartOne(string expected, string[] input) {
      Solver s = new Day04Solver();
      string result = s.SolvePartOne(input);
      Assert.That(result, Is.EqualTo(expected));
    }

    public void TestPartTwo(string expected, string[] input) {
      Solver s = new Day04Solver();
      string result = s.SolvePartTwo(input);
      Assert.That(result, Is.EqualTo(expected));
    }
  }
}
