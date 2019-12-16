using System;
using System.Collections.Generic;

using AdventOfCode.Computer;

namespace AdventOfCode.Solvers.Day11 {
  public class HullPaintingRobot : IntcodeComputer {
    public int X { get; set; }
    public int Y { get; set; }
    public int Direction { get; set; }

    private const int DIRECTIONS = 4;
    private Dictionary<int, Move> Directions;
    private bool Interrupt { get; set; }

    public HullPaintingRobot(long[] program) : base(program) {
      X = 0;
      Y = 0;

      Interrupt = true;
      Operations[3] = BlockingInputOperation;
      Operations[4] = BlockingOutputOperation;

      Directions = new Dictionary<int, Move>(DIRECTIONS);
      Directions.Add(0, new MoveUp());
      Directions.Add(1, new MoveRight());
      Directions.Add(2, new MoveDown());
      Directions.Add(3, new MoveLeft());

      Direction = 0;
    }

    public void Move() {
      int x = X;
      int y = Y;

      Directions[Direction].Move(ref x, ref y);

      X = x;
      Y = y;
    }

    public void Rotate(long direction) {
      int rotationDirection = direction == 0 ? -1 : 1;
      Direction = (Direction + rotationDirection + DIRECTIONS) % DIRECTIONS;
    }

    private void BlockingInputOperation(long[] modes) {
      if(Interrupt) {
        CurrentState = State.Paused;
        Interrupt = false;
      } else {
        InputOperation(modes);
        Interrupt = true;
      }
    }

    private void BlockingOutputOperation(long[] modes) {
      CurrentState = State.Paused;
      OutputOperation(modes);
    }
  }
}
