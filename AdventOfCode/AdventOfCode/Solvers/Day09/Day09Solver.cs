using System;
using System.Collections.Generic;
using System.Linq;

using AdventOfCode.Computer;

namespace AdventOfCode.Solvers {
  public class Day09Solver : Solver {

    public string SolvePartOne(string[] input) {
      long[] program = string.Join(",", input).Split(",")
        .Select(x => Int64.Parse(x)).ToArray();

      IntcodeComputer ic = new IntcodeComputer(program, 1);
      ic.Run();
      return ic.Output.ToString();
    }

    public string SolvePartTwo(string[] input) {
      long[] program = string.Join(",", input).Split(",")
        .Select(x => Int64.Parse(x)).ToArray();

      IntcodeComputer ic = new IntcodeComputer(program, 2);
      ic.Run();
      return ic.Output.ToString();
    }
  }
}
