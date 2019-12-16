using System.Collections.Generic;

namespace AdventOfCode.Solvers.Day11 {
  public class Position {
    public int X { get; set; }
    public int Y { get; set; }

    public Position(int x, int y) {
      X = x;
      Y = y;
    }
  }

  public class PositionEqualityComparer : IEqualityComparer<Position> {
    public bool Equals(Position pos, Position other) {
      return (pos.X == other.X) && (pos.Y == other.Y);
    }

    public int GetHashCode(Position pos) {
      string hashString = $"{pos.X}|{pos.Y}";
      return hashString.GetHashCode();
    }
  }
}
