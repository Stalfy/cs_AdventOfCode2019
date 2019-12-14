using NUnit.Framework;

using AdventOfCode.Solvers;

namespace AdventOfCode.Tests {
  public class Day10SolverTests {

    [TestCase("Best asteroid (3,4) can view 8 asteroids.", new string[] {
        ".#..#",
        ".....",
        "#####",
        "....#",
        "...##"
    })]
    [TestCase("Best asteroid (5,8) can view 33 asteroids.", new string[] {
      "......#.#.",
      "#..#.#....",
      "..#######.",
      ".#.#.###..",
      ".#..#.....",
      "..#....#.#",
      "#..#....#.",
      ".##.#..###",
      "##...#..#.",
      ".#....####"
    })]
    public void TestPartOne(string expected, string[] input) {
      Solver s = new Day10Solver();
      string result = s.SolvePartOne(input);
      Assert.That(result, Is.EqualTo(expected));
    }

    public void TestPartTwo(string expected, string[] input) {
      Solver s = new Day10Solver();
      string result = s.SolvePartTwo(input);
      Assert.That(result, Is.EqualTo(expected));
    }
  }
}
