using System;
using System.Collections.Generic;
using System.Linq;

using AdventOfCode.Solvers.Day02;

namespace AdventOfCode.Solvers {
  public class Day02Solver : Solver {
    public string SolvePartOne(string[] input) {
      int[] program = string.Join(",", input)
        .Split(new char[] { ',' })
        .Select(x => Int32.Parse(x))
        .ToArray();


      program[1] = 12;
      program[2] = 2;

      IntcodeComputer ic = new IntcodeComputer();
      int[] compiledProgram = ic.Compile(program);
      return program[0].ToString();
    }

    public string SolvePartTwo(string[] input) {
      return "";
    }
  }
}
