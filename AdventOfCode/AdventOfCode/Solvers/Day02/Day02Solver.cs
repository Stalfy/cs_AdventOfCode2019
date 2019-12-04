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

      int[] compiledProgram = CompileWithNounAndVerb(program, 12, 2);
      return compiledProgram[0].ToString();
    }

    public string SolvePartTwo(string[] input) {
      int[] prog = string.Join(",", input)
        .Split(",")
        .Select(x => Int32.Parse(x))
        .ToArray();

      int desired = 19690720;
      int[] compiled = (int[]) prog.Clone();

      int noun = 0;
      int verb = 0;
      for(noun = 0; desired != compiled[0] && noun <= 99; noun++) {
        for(verb = 0; desired != compiled[0] && verb <= 99; verb++) {
          compiled = CompileWithNounAndVerb((int[]) prog.Clone(), noun, verb);
        } 
      }

      return (100 * --noun + --verb).ToString();
    }

    private int[] CompileWithNounAndVerb(int[] program, int noun, int verb) {
      program[1] = noun;
      program[2] = verb;

      IntcodeComputer ic = new IntcodeComputer();
      return ic.Compile(program);
    }
  }
}
