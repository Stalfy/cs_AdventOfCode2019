using NUnit.Framework;

using AdventOfCode.Solvers;

namespace AdventOfCode.Tests {
  public class Day05SolverTests {

    [TestCase("1", new string[] { "4,1,99" })]
    public void TestPartOne(string expected, string[] input) {
      Solver s = new Day05Solver();
      string result = s.SolvePartOne(input);
      Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("1", new string[] { "1106,0,5,3,1,104,1,99" })]
    public void TestPartTwo(string expected, string[] input) {
      Solver s = new Day05Solver();
      string result = s.SolvePartTwo(input);
      Assert.That(result, Is.EqualTo(expected));
    }
  }
}
