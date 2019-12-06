using System;
using System.Collections.Generic;

namespace AdventOfCode.Solvers {
  public class IntcodeComputer {
    private Dictionary<int, Func<int[], int, int[], int>> operations;
    private Dictionary<int, Func<int[], int, int>> getters;
    public int Output { get; set; }

    public IntcodeComputer() {
      operations = new Dictionary<int, Func<int[], int, int[], int>>(); 
      operations.Add(1, AddOperation);
      operations.Add(2, MultiplyOperation);
      operations.Add(3, InputOperation);
      operations.Add(4, OutputOperation);
      operations.Add(99, HaltOperation);

      getters = new Dictionary<int, Func<int[], int, int>>(); 
      getters.Add(0, PositionModeGetter);
      getters.Add(1, ImmediateModeGetter);

      Output = 0;
    }

    public int[] Compile(int[] prog) {
      int idx = 0;
      int opcode = 0;
      int[] parameterModes = new int[2];

      do {
        opcode = prog[idx] % 100;
        parameterModes[0] = (prog[idx] / 100) % 10;
        parameterModes[1] = (prog[idx] / 1000) % 10;

        idx = operations[prog[idx]](prog, idx, parameterModes);
      } while (99 != opcode && 0 == Output);

      return prog;
    }

    private int AddOperation(int[] prog, int idx, int[] modes) {
      prog[prog[idx + 3]] = getters[modes[0]](prog, idx + 1) + getters[modes[1]](prog, idx + 2); 
      return idx + 4;
    }

    private int MultiplyOperation(int[] prog, int idx, int[] modes) {
      prog[prog[idx + 3]] = getters[modes[0]](prog, idx + 1) * getters[modes[1]](prog, idx + 2); 
      return idx + 4;
    }

    private int InputOperation(int[] prog, int idx, int[] modes) {
      prog[prog[idx + 1]] = 1;
      return idx + 2;
    }

    private int OutputOperation(int[] prog, int idx, int[] modes) {
      Output = getters[modes[0]](prog, idx);
      return idx + 2;
    }

    private int HaltOperation(int[] prog, int idx, int[] modes) {
      return idx;
    }

    private int PositionModeGetter(int[] prog, int idx) {
      return prog[prog[idx]];
    }

    private int ImmediateModeGetter(int[] prog, int idx) {
      return prog[idx];
    }
  }
}
