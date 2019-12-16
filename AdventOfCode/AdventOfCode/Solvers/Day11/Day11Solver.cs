using System;
using System.Collections.Generic;
using System.Linq;

using AdventOfCode.Computer;
using AdventOfCode.Solvers.Day11;

namespace AdventOfCode.Solvers {
  public class Day11Solver : Solver {
    public string SolvePartOne(string[] input) {
      long[] program = string.Join(",", input).Split(",")
        .Select(x => Int64.Parse(x)).ToArray();

      Dictionary<Position, long> positionColors = ExecuteProgram(program, 0);

      return positionColors.Count.ToString();
    }

    public string SolvePartTwo(string[] input) {
      long[] program = string.Join(",", input).Split(",")
        .Select(x => Int64.Parse(x)).ToArray();

      Dictionary<Position, long> positionColors = ExecuteProgram(program, 1);

      int[] xPositions = positionColors.Select(pos => pos.Key.X).ToArray();
      int[] yPositions = positionColors.Select(pos => pos.Key.Y).ToArray();

      long val;
      string str = "";
      for(int y = yPositions.Min(); y <= yPositions.Max(); y++) {
        str = string.Concat(str, "\n");
        for(int x = xPositions.Min(); x <= xPositions.Max(); x++) {
          positionColors.TryGetValue(new Position(x, y), out val);
          str = string.Concat(str, val);
        }
      }

      str = str.Replace('0', '\u2B2D');
      str = str.Replace('1', '\u2B2C');

      return str;
    }

    private Dictionary<Position, long> ExecuteProgram(long[] program, long baseColor) {
      HullPaintingRobot hpr = new HullPaintingRobot(program);
      Dictionary<Position, long> positionColor =
        new Dictionary<Position, long>(new PositionEqualityComparer());

      long input = baseColor;
      Position hprPos = new Position(0, 0);

      positionColor[hprPos] = baseColor;
      hpr.Run();
      hpr.Input = baseColor;

      while(hpr.CurrentState != IntcodeComputer.State.Halted) {
        // Color.
        hpr.Run();
        positionColor[hprPos] = hpr.Output;

        // Rotation.
        hpr.Run();
        hpr.Rotate(hpr.Output);

        hpr.Move();

        // Input.
        hpr.Run();
        hprPos = new Position(hpr.X, hpr.Y);
        positionColor.TryGetValue(hprPos, out input);
        hpr.Input = input;
      }

      return positionColor;
    }
  }
}
