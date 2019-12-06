using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solvers {
  public class Day05Solver : Solver {
    public string SolvePartOne(string[] input) {
      int[] program = string.Join(",", input).Split(",")
        .Select(x => Int32.Parse(x)).ToArray();

      IntcodeComputer ic = new IntcodeComputer();

      if(ic.Compile(program)) {
        return ic.Output.ToString();
      } else {
        return (-1).ToString();
      }
    }

    public string SolvePartTwo(string[] input) {
      int[] program = string.Join(",", input).Split(",")
        .Select(x => Int32.Parse(x)).ToArray();
      return "";
    }
  }
}
