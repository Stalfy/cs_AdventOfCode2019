using System;
using System.Collections.Generic;
using System.Linq;

using AdventOfCode.Computer;

namespace AdventOfCode.Solvers {
  public class Day05Solver : Solver {
    public string SolvePartOne(string[] input) {
      int[] program = string.Join(",", input).Split(",")
        .Select(x => Int32.Parse(x)).ToArray();

      IntcodeComputer ic = new IntcodeComputer(program, 1);

      ic.Run();
      return ic.Output.ToString();
    }

    public string SolvePartTwo(string[] input) {
      int[] program = string.Join(",", input).Split(",")
        .Select(x => Int32.Parse(x)).ToArray();

      IntcodeComputer ic = new IntcodeComputer(program, 5);

      ic.Run();
      return ic.Output.ToString();
    }
  }
}
