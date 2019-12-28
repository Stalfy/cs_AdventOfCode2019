using NUnit.Framework;

using AdventOfCode.Solvers;

namespace AdventOfCode.Tests {
  public class Day16SolverTests {

    [TestCase("01029498", new string[] { "12345678" }, 4)]
    [TestCase("24176176", new string[] { "80871224585914546619083218645595" }, 100)]
    [TestCase("73745418", new string[] { "19617804207202209144916044189917" }, 100)]
    [TestCase("52432133", new string[] { "69317163492948606335995924319873" }, 100)]
    public void TestPartOne(string expected, string[] input, int phases) {
      Day16Solver s = new Day16Solver();
      string result = s.SolvePartOne(input, phases);
      Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("84462026", new string[] { "03036732577212944063491565474664" })]
    [TestCase("78725270", new string[] { "02935109699940807407585447034323" })]
    [TestCase("53553731", new string[] { "03081770884921959731165446850517" })]
    public void TestPartTwo(string expected, string[] input) {
      Solver s = new Day16Solver();
      string result = s.SolvePartTwo(input);
      Assert.That(result, Is.EqualTo(expected));
    }
  }
}
