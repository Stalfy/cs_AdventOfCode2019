using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace AdventOfCode.Computer {
  public class Arcade : IntcodeComputer {
    public enum Tile { Empty = 0, Wall, Block, HorizontalPaddle, Ball }

    public int MaxX { get; set; }
    public int MaxY { get; set; }
    public Dictionary<Point, Tile> Tiles;
    public Dictionary<Tile, char> UIElements;

    public Arcade(long[] program) : base(program) {
      Operations[3] = ConsoleInputOperation;
      Operations[4] = BlockingOutputOperation;

      Tiles = new Dictionary<Point, Tile>();
      MaxX = 0;
      MaxY = 0;

      UIElements = new Dictionary<Tile, char>(5);
      UIElements.Add(Tile.Empty,            '.');
      UIElements.Add(Tile.Wall,             '+');
      UIElements.Add(Tile.Block,            '#');
      UIElements.Add(Tile.HorizontalPaddle, '~');
      UIElements.Add(Tile.Ball,             'O');
    }

    public void UpdateTile(Point p, int tileId) {
      Tiles[p] = (Tile) tileId;
      MaxX = Tiles.Select(t => t.Key.X).ToArray().Max();
      MaxY = Tiles.Select(t => t.Key.Y).ToArray().Max();
    }

    public int CountTilesOfType(Tile tile) {
      return Tiles.Where(x => x.Value == tile).Count();
    }

    public string GetVisualRepresentation() {
      string str = "";
      Tile tile;

      for(int j = 0; j <= MaxY; j++) {
        for(int i = 0; i <= MaxX; i++) {
          Tiles.TryGetValue(new Point(i,j), out tile);
          str = string.Concat(str, UIElements[tile]);
        }

        str = string.Concat(str, "\n");
      }

      return str;
    }

    private void ConsoleInputOperation(long[] modes) {
      int paddleX = Tiles.Where(t => t.Value == Tile.HorizontalPaddle).First().Key.X;
      int ballX = Tiles.Where(t => t.Value == Tile.Ball).First().Key.X;

      if(ballX < paddleX) {
        Input = -1;
      }

      if(ballX == paddleX) {
        Input = 0;
      }

      if(ballX > paddleX) {
        Input = 1;
      }

      InputOperation(modes);
    }

    private void BlockingOutputOperation(long[] modes) {
      CurrentState = State.Paused;
      OutputOperation(modes);
    }
  }
}
