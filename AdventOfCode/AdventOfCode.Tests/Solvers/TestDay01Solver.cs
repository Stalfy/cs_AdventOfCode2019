using NUnit.Framework;

using AdventOfCode.Solvers;

namespace AdventOfCode.Tests {
  public class TestDay01Solver {

    [TestCase("2",  new string[] { "12" })]
    [TestCase("2",  new string[] { "14" })]
    [TestCase("654",  new string[] { "1969" })]
    [TestCase("33583",  new string[] { "100756" })]
    [TestCase("4", new string[] { "12", "14" })]
    public void TestPartOne(string expected, string[] input) {
      Solver s = new Day01Solver();
      string result = s.SolvePartOne(input);
      Assert.That(result, Is.EqualTo(expected));
    }

    /*
    [TestCase("2", new string[] { "14" })]
    [TestCase("966", new string[] { "1969" })]
    [TestCase("50346", new string[] { "100756" })]
    public void TestPartTwo(string expected, string[] input) {
      Solver s = new Day01Solver();
      string result = s.SolvePartTwo(input);
      Assert.That(result, Is.EqualTo(expected));
    }
    */
  }
}
