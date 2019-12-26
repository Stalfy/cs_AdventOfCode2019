using System;
using System.Collections.Generic;
using System.Drawing;

namespace AdventOfCode.Computer {
  public class RepairDroid : IntcodeComputer {
    const long NORTH = 1;
    const long SOUTH = 2;
    const long WEST  = 3;
    const long EAST  = 4;

    public const long WALL = 0;
    public const long FLOOR = 1;
    public const long DEST = 2;

    private bool Interrupt;

    public RepairDroid(long[] program) : base(program) {
      Interrupt = false;
      Operations[3] = BlockingInputOperation;
      Output = FLOOR;
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

    public Dictionary<Point, long> MapOxygenTank() {
      Point position = new Point(0, 0);
      Dictionary<Point, long> area = new Dictionary<Point, long>();

      ExploreAllDirections(position, area);

      return area;
    }

    private void ExploreAllDirections(Point position, Dictionary<Point, long> area) {
      if(area.ContainsKey(position)) {
        return;
      }

      area[position] = Output;
      Explore(position, area, NORTH, SOUTH);
      Explore(position, area, EAST, WEST);
      Explore(position, area, SOUTH, NORTH);
      Explore(position, area, WEST, EAST);
    }

    private void Explore(Point pos, Dictionary<Point, long> area, long direction, long oppositeDirection) {
      Point move = GetNextPosition(pos, direction);
      Move(direction);

      if(WALL != Output) {
        ExploreAllDirections(move, area);
        Move(oppositeDirection);
      } else {
        area[move] = WALL;
      }
    }

    private void Move(long direction) {
      Input = direction;
      Run();
    }

    private Point GetNextPosition(Point position, long direction) {
      switch(direction) {
        case NORTH:
          return new Point(position.X, position.Y - 1);
        case SOUTH:
          return new Point(position.X, position.Y + 1);
        case EAST:
          return new Point(position.X + 1, position.Y);
        case WEST:
          return new Point(position.X - 1, position.Y);
      }

      return new Point(0, 0);
    }
  }
}
