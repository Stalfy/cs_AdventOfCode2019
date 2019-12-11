using NUnit.Framework;

using AdventOfCode.Solvers;

namespace AdventOfCode.Tests {
  public class Day09SolverTests {

    [TestCase("1219070632396864", new string[] { "1102,34915192,34915192,7,4,7,99,0" })]
    [TestCase("1125899906842624", new string[] { "104,1125899906842624,99" })]
    public void TestPartOne(string expected, string[] input) {
      Solver s = new Day09Solver();
      string result = s.SolvePartOne(input);
      Assert.That(result, Is.EqualTo(expected));
    }

    public void TestPartTwo(string expected, string[] input) {
      Solver s = new Day09Solver();
      string result = s.SolvePartTwo(input);
      Assert.That(result, Is.EqualTo(expected));
    }
  }
}
