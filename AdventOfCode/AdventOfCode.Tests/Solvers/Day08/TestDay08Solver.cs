using NUnit.Framework;

using AdventOfCode.Solvers;

namespace AdventOfCode.Tests {
  public class Day08SolverTests {

    [TestCase("3", new string[] { "001201121112"  })]
    public void TestPartOne(string expected, string[] input) {
      Day08Solver s = new Day08Solver();
      string result = s.SolvePartOne(input, 2, 2);
      Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("\n⬭⬬⬬⬭", new string[] { "0222112222120000"  })]
    public void TestPartTwo(string expected, string[] input) {
      Day08Solver s = new Day08Solver();
      string result = s.SolvePartTwo(input, 4, 1);
      Assert.That(result, Is.EqualTo(expected));
    }
  }
}
