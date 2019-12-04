using NUnit.Framework;

using AdventOfCode.Solvers;

namespace AdventOfCode.Tests {
  public class Day03SolverTests {

    [TestCase("6",  new string[] {
        "R8,U5,L5,D3",
        "U7,R6,D4,L4"
    })]
    [TestCase("159",  new string[] { 
        "R75,D30,R83,U83,L12,D49,R71,U7,L72", 
        "U62,R66,U55,R34,D71,R55,D58,R83" 
    })]
    [TestCase("135",  new string[] { 
        "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51",
        "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7"
    })]
    public void TestPartOne(string expected, string[] input) {
      Solver s = new Day03Solver();
      string result = s.SolvePartOne(input);
      Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("30",  new string[] {
        "R8,U5,L5,D3",
        "U7,R6,D4,L4"
    })]
    [TestCase("610",  new string[] { 
        "R75,D30,R83,U83,L12,D49,R71,U7,L72", 
        "U62,R66,U55,R34,D71,R55,D58,R83" 
    })]
    [TestCase("410",  new string[] { 
        "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51",
        "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7"
    })]
    public void TestPartTwo(string expected, string[] input) {
      Solver s = new Day03Solver();
      string result = s.SolvePartTwo(input);
      Assert.That(result, Is.EqualTo(expected));
    }
  }
}
