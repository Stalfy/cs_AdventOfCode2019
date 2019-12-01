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
      int fuel = input.Aggregate(0, (acc, x) => acc + RequiredFuel(Int32.Parse(x)));
      return fuel.ToString();
    }

    public int RequiredFuel(int x) {
      if (0 == x) {
        return 0;
      }

      int requiredFuel = Math.Max(0, x / 3 - 2);
      return requiredFuel + RequiredFuel(requiredFuel);
    }
  }
}
