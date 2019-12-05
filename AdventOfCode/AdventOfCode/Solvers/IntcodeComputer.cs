using System;
using System.Collections.Generic;

namespace AdventOfCode.Solvers {
  public class IntcodeComputer {
    private Dictionary<int, Func<int[], int, int>> operations;

    public IntcodeComputer() {
      operations = new Dictionary<int, Func<int[], int, int>>(); 
      operations.Add(1, AddOperation);
      operations.Add(2, MultiplyOperation);
    }

    public int[] Compile(int[] program) {
      int idx = 0;

      while (99 != program[idx]) {
        idx = operations[program[idx]](program, idx);
      }

      return program;
    }

    private int AddOperation(int[] program, int idx) {
      program[program[idx + 3]] = program[program[idx + 1]] + program[program[idx + 2]];
      return idx + 4;
    }

    private int MultiplyOperation(int[] program, int idx) {
      program[program[idx + 3]] = program[program[idx + 1]] * program[program[idx + 2]];
      return idx + 4;
    }
  }
}
