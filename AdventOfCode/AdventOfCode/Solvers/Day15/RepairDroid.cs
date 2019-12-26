using System;
using System.Collections.Generic;

namespace AdventOfCode.Computer {
  public class RepairDroid : IntcodeComputer {
    private bool Interrupt;

    public RepairDroid(long[] program) : base(program) {
      Interrupt = false;
      Operations[3] = BlockingInputOperation;
    }

    public long Move(long direction) {
      Input = direction;
      Run();
      return Output;
    }

    private void BlockingInputOperation(long[] modes) {
      if (Interrupt) {
        CurrentState = State.Paused;
        Interrupt = false;
      } else {
        InputOperation(modes);
        Interrupt = true;
      }
    }
  }
}
