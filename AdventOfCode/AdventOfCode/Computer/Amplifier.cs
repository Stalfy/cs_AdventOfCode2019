using System;
using System.Collections.Generic;

namespace AdventOfCode.Computer {
  public class Amplifier : IntcodeComputer {
    private int Phase;
    private bool Interrupt;

    public Amplifier(int[] program, int phase) : base(program) {
      Phase = phase;
      Interrupt = false;
      operations[3] = PhaseOperation;
    }

    private void PhaseOperation(int[] modes) {
      _Program[_Program[Idx + 1]] = Phase;
      operations[3] = BlockingInputOperation;

      Idx += 2;
    }

    private void BlockingInputOperation(int[] modes) {
      if (Interrupt && Phase >= 5) {
        CurrentState = State.Paused;
        Interrupt = false;
      } else {
        InputOperation(modes);
        Interrupt = true;
      }
    }
  }
}
