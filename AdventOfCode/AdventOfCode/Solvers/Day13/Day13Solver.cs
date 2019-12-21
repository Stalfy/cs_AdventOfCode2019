using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using AdventOfCode.Computer;

namespace AdventOfCode.Solvers {
  public class Day13Solver : Solver {

    public string SolvePartOne(string[] input) {
      long[] game = string.Join(",", input)
        .Split(",")
        .Select(x => Int64.Parse(x))
        .ToArray();
      Arcade arcade = new Arcade(game);

      Point p;
      int tileId;
      do {
        p = new Point(0, 0);

        arcade.Run();
        p.X = (int) arcade.Output;

        arcade.Run();
        p.Y = (int) arcade.Output;

        arcade.Run();
        tileId = (int) arcade.Output;

        arcade.UpdateTile(p, tileId);
      } while (arcade.CurrentState != IntcodeComputer.State.Halted);

      return arcade.CountTilesOfType(Arcade.Tile.Block).ToString();
    }

    public string SolvePartTwo(string[] input) {
      long[] game = string.Join(",", input)
        .Split(",")
        .Select(x => Int64.Parse(x))
        .ToArray();

      game[0] = 2;

      Arcade arcade = new Arcade(game);
      arcade.Input = 0;

      int score = 0;
      Point p;
      int tileId;
      do {
        p = new Point(0, 0);

        arcade.Run();
        p.X = (int) arcade.Output;

        arcade.Run();
        p.Y = (int) arcade.Output;

        arcade.Run();
        tileId = (int) arcade.Output;

        if(-1 == p.X) {
          score = tileId;
        } else {
          arcade.UpdateTile(p, tileId);
        }

        // Console.Clear();
        // Console.WriteLine($"Score: {score}");
        // Console.WriteLine($"{arcade.GetVisualRepresentation()}");
      } while (arcade.CurrentState != IntcodeComputer.State.Halted);

      return score.ToString();
    }
  }
}
