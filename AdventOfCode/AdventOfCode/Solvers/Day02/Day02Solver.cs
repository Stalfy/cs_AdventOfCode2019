using System;
using System.Collections.Generic;
using System.Linq;

using AdventOfCode.Computer;

namespace AdventOfCode.Solvers {
  public class Day02Solver : Solver {
    public string SolvePartOne(string[] input) {
      int[] program = string.Join(",", input).Split(",")
        .Select(x => Int32.Parse(x)).ToArray();

      CompileWithNounAndVerb(program, 12, 2);
      return program[0].ToString();
    }

    public string SolvePartTwo(string[] input) {
      int[] prog = string.Join(",", input).Split(",")
        .Select(x => Int32.Parse(x)).ToArray();

      int desired = 19690720;
      int noun = 0;
      int verb = 0;
      int[] compiled = (int[]) prog.Clone();
      for(noun = 0; desired != compiled[0] && noun <= 99; noun++) {
        for(verb = 0; desired != compiled[0] && verb <= 99; verb++) {
          compiled = (int[]) prog.Clone();
          CompileWithNounAndVerb(compiled, noun, verb);
        } 
      }

      return (100 * --noun + --verb).ToString();
    }

    private void CompileWithNounAndVerb(int[] program, int noun, int verb) {
      program[1] = noun;
      program[2] = verb;

      IntcodeComputer ic = new IntcodeComputer(program, 1);
      ic.Run();
    }
  }
}
