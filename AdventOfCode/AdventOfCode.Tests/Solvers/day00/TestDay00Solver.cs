using NUnit.Framework;

using AdventOfCode.Solvers;

namespace AdventOfCode.Tests {
  public class Day00SolverTests {

    [TestCase("0",  new string[] { "(())" })]
    [TestCase("0",  new string[] { "()()" })]
    [TestCase("3",  new string[] { "(((" })]
    [TestCase("3",  new string[] { "(()(()(" })]
    [TestCase("3",  new string[] { "))(((((" })]
    [TestCase("-1", new string[] { "())" })]
    [TestCase("-1", new string[] { "))(" })]
    [TestCase("-3", new string[] { ")))" })]
    [TestCase("-3", new string[] { ")())())" })]
    public void TestPartOne(string expected, string[] input) {
      Solver s = new Day00Solver();
      string result = s.SolvePartOne(input);
      Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("1", new string[] { ")" })]
    [TestCase("5", new string[] { "()())" })]
    public void TestPartTwo(string expected, string[] input) {
      Solver s = new Day00Solver();
      string result = s.SolvePartTwo(input);
      Assert.That(result, Is.EqualTo(expected));
    }
  }
}
