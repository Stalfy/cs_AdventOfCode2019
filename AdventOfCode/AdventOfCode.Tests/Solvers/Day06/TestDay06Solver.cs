using NUnit.Framework;

using AdventOfCode.Solvers;

namespace AdventOfCode.Tests {
  public class Day06SolverTests {

    [TestCase("42", new string[] { "COM)B", "B)C", "C)D", "D)E", "E)F", "B)G", "G)H",
                                   "D)I", "E)J", "J)K", "K)L" })]
    public void TestPartOne(string expected, string[] input) {
      Solver s = new Day06Solver();
      string result = s.SolvePartOne(input);
      Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("4", new string[] { "COM)B", "B)C", "C)D", "D)E", "E)F", "B)G", "G)H",
                                  "D)I", "E)J", "J)K", "K)L", "K)YOU", "I)SAN" })]
    public void TestPartTwo(string expected, string[] input) {
      Solver s = new Day06Solver();
      string result = s.SolvePartTwo(input);
      Assert.That(result, Is.EqualTo(expected));
    }
  }
}
