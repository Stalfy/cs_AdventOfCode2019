using System;
using System.Collections.Generic;

namespace AdventOfCode.Computer {
  public class Amplifier : IntcodeComputer {
    private long Phase;
    private bool Interrupt;

    public Amplifier(long[] program, long phase) : base(program) {
      Phase = phase;
      Interrupt = false;
      Operations[3] = PhaseOperation;
    }

    private void PhaseOperation(long[] modes) {
      Store(Idx + 1, Phase, modes[0]);
      Operations[3] = BlockingInputOperation;

      Idx += 2;
    }

    private void BlockingInputOperation(long[] modes) {
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
