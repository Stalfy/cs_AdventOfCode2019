using NUnit.Framework;

using AdventOfCode.Solvers;

namespace AdventOfCode.Tests {
  public class TestDay02Solver {
    [TestCase("5", new string[] { "1,0,0,0,99,0,0,0,0,0,0,0,3" })]
    [TestCase("6", new string[] { "2,0,0,0,99,0,0,0,0,0,0,0,3" })]
    public void TestPartOne(string expected, string[] input) {
      Solver s = new Day02Solver();
      string result = s.SolvePartOne(input);
      Assert.That(result, Is.EqualTo(expected));
    }
  }
}
