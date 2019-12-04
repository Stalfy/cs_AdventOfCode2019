using System;
using System.Collections.Generic;

namespace AdventOfCode.Solvers.Day02 {
  public class IntcodeComputer {
    private Dictionary<int, Func<int[], int, int>> operations;

    public IntcodeComputer() {
      operations = new Dictionary<int, Func<int[], int, int>>(); 
      operations.Add(1, AddOperation);
      operations.Add(2, MultiplyOperation);
    }

    public int[] Compile(int[] program) {
      for(int i = 0; 99 != program[i] && i < program.Length; i += 4) {
        program[program[i + 3]] = operations[program[i]](program, i);
      }

      return program;
    }

    private int AddOperation(int[] program, int index) {
      return program[program[index + 1]] + program[program[index + 2]];
    }

    private int MultiplyOperation(int[] program, int index) {
      return program[program[index + 1]] * program[program[index + 2]];
    }
  }
}
