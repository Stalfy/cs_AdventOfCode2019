using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solvers {
  public class Day01Solver : Solver {
    public string SolvePartOne(string[] input) {
      int mass = input.Aggregate(0, (acc, x) => acc + Int32.Parse(x));
      int fuel = mass / 3 - 2 * input.Length;
      return fuel.ToString();
    }

    public string SolvePartTwo(string[] input) {
      return "";
    }
  }
}
