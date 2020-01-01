using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCode.Solvers.Day17 {
  public class ScaffoldPathBuilder {
    public enum Direction { Up = 0, Left, Down, Right }

    public List<long> GetScaffoldInstructions(Dictionary<Point, long> scaffolding) {
      Point position = scaffolding.Where(x => x.Value != 35).Select(x => x.Key).First();
      position = new Point(position.X, position.Y);

      Direction direction = GetInitialDirection(scaffolding);

      List<long> instructions = new List<long>();

      bool canGoForward = CanGoForward(scaffolding, position, direction);
      bool canTurnLeft = CanTurnLeft(scaffolding, position, direction);
      bool canTurnRight = CanTurnRight(scaffolding, position, direction);

      while(canGoForward || canTurnLeft || canTurnRight) {
        if(canGoForward) {
          long steps = MoveForward(scaffolding, ref position, direction);
          instructions.AddRange(ConvertStepsToAscii(steps));
          instructions.Add(',' + 0);
        } else {
          if(canTurnLeft) {
            instructions.Add('L' + 0);
            instructions.Add(',' + 0);
            direction = TurnLeft(direction);

          } else if (canTurnRight) {
            instructions.Add('R' + 0);
            instructions.Add(',' + 0);
            direction = TurnRight(direction);
          }
        }

        canGoForward = CanGoForward(scaffolding, position, direction);
        canTurnLeft = CanTurnLeft(scaffolding, position, direction);
        canTurnRight = CanTurnRight(scaffolding, position, direction);
      }

      instructions.RemoveAt(instructions.Count - 1);
      return instructions;
    }

    public Direction GetInitialDirection(Dictionary<Point, long> scaffolding) {
      if(false == default(KeyValuePair<Point, long>).Equals( 
            scaffolding.Where(x => x.Value == 94).FirstOrDefault())) {
        return Direction.Up;
      }

      if(false == default(KeyValuePair<Point, long>).Equals( 
            scaffolding.Where(x => x.Value == 118).FirstOrDefault())) {
        return Direction.Down;
      }

      if(false == default(KeyValuePair<Point, long>).Equals( 
            scaffolding.Where(x => x.Value == 60).FirstOrDefault())) {
        return Direction.Left;
      }

      if(false == default(KeyValuePair<Point, long>).Equals( 
            scaffolding.Where(x => x.Value == 62).FirstOrDefault())) {
        return Direction.Right;
      }

      return Direction.Up;
    }

    public long MoveForward(Dictionary<Point, long> scaf, ref Point pos, Direction dir) {
      long steps = 0;
      while(CanGoForward(scaf, pos, dir)) {
        pos = Move(pos, dir);
        steps++;
      }

      return steps;
    }

    public List<long> ConvertStepsToAscii(long steps) {
      List<long> asciiDigits = new List<long>();

      while(steps != 0) {
        asciiDigits.Add('0' + (steps % 10));
        steps /= 10;
      }

      asciiDigits.Reverse();
      return asciiDigits;
    }

    public Point Move(Point position, Direction direction) {
      switch(direction) {
        case Direction.Up:
          position.Y--;
          break;
        case Direction.Left:
          position.X--;
          break;
        case Direction.Down:
          position.Y++;
          break;
        case Direction.Right:
          position.X++;
          break;
      }

      return position;
    }

    public Direction TurnLeft(Direction direction) {
      Direction nextDir = direction;

      switch(direction) {
        case Direction.Up:
          nextDir = Direction.Left;
          break;
        case Direction.Left:
          nextDir = Direction.Down;
          break;
        case Direction.Down:
          nextDir = Direction.Right;
          break;
        case Direction.Right:
          nextDir = Direction.Up;
          break;
      }

      return nextDir;
    }

    public Direction TurnRight(Direction direction) {
      Direction nextDir = direction;

      switch(direction) {
        case Direction.Up:
          nextDir = Direction.Right;
          break;
        case Direction.Left:
          nextDir = Direction.Up;
          break;
        case Direction.Down:
          nextDir = Direction.Left;
          break;
        case Direction.Right:
          nextDir = Direction.Down;
          break;
      }

      return nextDir;
    }

    public bool CanGoForward(Dictionary<Point, long> scaffolding, Point position,
        Direction direction) {
      Dictionary<Direction, Func<Dictionary<Point, long>, Point, bool>> funcs =
        new Dictionary<Direction, Func<Dictionary<Point, long>, Point, bool>>();

      funcs[Direction.Up] = IsUpPositionScaffolding;
      funcs[Direction.Left] = IsLeftPositionScaffolding;
      funcs[Direction.Down] = IsDownPositionScaffolding;
      funcs[Direction.Right] = IsRightPositionScaffolding;

      return funcs[direction](scaffolding, position);
    }

    public bool CanTurnLeft(Dictionary<Point, long> scaffolding, Point position,
        Direction direction) {
      Dictionary<Direction, Func<Dictionary<Point, long>, Point, bool>> funcs =
        new Dictionary<Direction, Func<Dictionary<Point, long>, Point, bool>>();

      funcs[Direction.Up] = IsLeftPositionScaffolding;
      funcs[Direction.Left] = IsDownPositionScaffolding;
      funcs[Direction.Down] = IsRightPositionScaffolding;
      funcs[Direction.Right] = IsUpPositionScaffolding;

      return funcs[direction](scaffolding, position);
    }

    public bool CanTurnRight(Dictionary<Point, long> scaffolding, Point position,
        Direction direction) {
      Dictionary<Direction, Func<Dictionary<Point, long>, Point, bool>> funcs =
        new Dictionary<Direction, Func<Dictionary<Point, long>, Point, bool>>();

      funcs[Direction.Up] = IsRightPositionScaffolding;
      funcs[Direction.Left] = IsUpPositionScaffolding;
      funcs[Direction.Down] = IsLeftPositionScaffolding;
      funcs[Direction.Right] = IsDownPositionScaffolding;

      return funcs[direction](scaffolding, position);
    }

    public bool IsLeftPositionScaffolding(Dictionary<Point, long> scaffolding,
        Point position) {
      return scaffolding.ContainsKey(new Point(position.X - 1, position.Y));
    }

    public bool IsUpPositionScaffolding(Dictionary<Point, long> scaffolding,
        Point position) {
      return scaffolding.ContainsKey(new Point(position.X, position.Y - 1));
    }

    public bool IsRightPositionScaffolding(Dictionary<Point, long> scaffolding,
        Point position) {
      return scaffolding.ContainsKey(new Point(position.X + 1, position.Y));
    }

    public bool IsDownPositionScaffolding(Dictionary<Point, long> scaffolding,
        Point position) {
      return scaffolding.ContainsKey(new Point(position.X, position.Y + 1));
    }
  }
}
