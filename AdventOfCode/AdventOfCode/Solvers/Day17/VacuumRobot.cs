using System;

namespace AdventOfCode.Computer {
  public class VacuumRobot : IntcodeComputer {
    public VacuumRobot(long[] prog, bool blockInput, bool blockOutput) : base(prog) {

      if(blockInput) {
        Input = -1;
        Operations[3] = BlockingInputOperation;
      }

      Operations[4] = BlockingOutputOperation;
      if(!blockOutput) {
        Operations[4] = DisplayOutputOperation;
      }
    }

    private void BlockingInputOperation(long[] modes) {
      if (Input == -1) {
        CurrentState = State.Paused;
      } else {
        InputOperation(modes);
        Input = -1;
      }
    }

    private void BlockingOutputOperation(long[] modes) {
      CurrentState = State.Paused;
      OutputOperation(modes);
    }

    private void  DisplayOutputOperation(long[] modes) {
      OutputOperation(modes);
      if(Output < 256) {
        Console.Write(Convert.ToChar(Output));  
      } else {
        Console.Write(Output);
      }
    }
  }
}
