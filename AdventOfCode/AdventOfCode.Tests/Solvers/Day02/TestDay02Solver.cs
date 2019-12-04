using NUnit.Framework;

using AdventOfCode.Solvers;

using System;
using System.Text;
namespace AdventOfCode.Tests {
  public class Day02SolverTests {
    [TestCase("5", new string[] { "1,0,0,0,99,0,0,0,0,0,0,0,3" })]
    [TestCase("6", new string[] { "2,0,0,0,99,0,0,0,0,0,0,0,3" })]
    public void TestPartOne(string expected, string[] input) {
      Solver s = new Day02Solver();
      string result = s.SolvePartOne(input);
      Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void TestPartTwo() {
      int[] program = new int[100];
      program[0] = 2;
      program[4] = 99;
      program[25] = 615335;
      program[72] = 32;

      StringBuilder sb = new StringBuilder();
      sb.Append(program[0]);

      for(int i = 1; i < program.Length; i++) {
        sb.Append(',');
        sb.Append(program[i]);
      }

      string[] input = new string[1];
      input[0] = sb.ToString();

      Solver s = new Day02Solver();
      string result = s.SolvePartTwo(input);
 
      string expected = (100 * 25 + 72).ToString();
      Assert.That(result, Is.EqualTo(expected));
    }
  }
}
