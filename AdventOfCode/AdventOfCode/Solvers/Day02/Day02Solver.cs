using System;
using System.Collections.Generic;
using System.Linq;

using AdventOfCode.Computer;

namespace AdventOfCode.Solvers {
  public class Day02Solver : Solver {
    public string SolvePartOne(string[] input) {
      long[] program = string.Join(",", input).Split(",")
        .Select(x => Int64.Parse(x)).ToArray();

      CompileWithNounAndVerb(program, 12, 2);
      return program[0].ToString();
    }

    public string SolvePartTwo(string[] input) {
      long[] prog = string.Join(",", input).Split(",")
        .Select(x => Int64.Parse(x)).ToArray();

      long desired = 19690720;
      long noun = 0;
      long verb = 0;
      long[] compiled = (long[]) prog.Clone();
      for(noun = 0; desired != compiled[0] && noun <= 99; noun++) {
        for(verb = 0; desired != compiled[0] && verb <= 99; verb++) {
          compiled = (long[]) prog.Clone();
          CompileWithNounAndVerb(compiled, noun, verb);
        } 
      }

      return (100 * --noun + --verb).ToString();
    }

    private void CompileWithNounAndVerb(long[] program, long noun, long verb) {
      program[1] = noun;
      program[2] = verb;

      IntcodeComputer ic = new IntcodeComputer(program, 1);
      ic.Run();
    }
  }
}
