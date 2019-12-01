using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solvers {
  public class Day01Solver : Solver {
    public string SolvePartOne(string[] input) {
      return input.Aggregate(0, (acc, x) => acc + Int32.Parse(x) / 3 - 2).ToString();
    }

    public string SolvePartTwo(string[] input) {
      return "";
    }
  }
}
