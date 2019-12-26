using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using AdventOfCode.Computer;

namespace AdventOfCode.Solvers {
  public class Day15Solver : Solver {
    const long NORTH = 1;
    const long SOUTH = 2;
    const long WEST  = 3;
    const long EAST  = 4;

    const long WALL = 0;
    const long MOVE = 1;
    const long DEST = 2;

    public string SolvePartOne(string[] input) {
      long[] program = string.Join(",", input)
        .Split(",")
        .Select(x => Int64.Parse(x))
        .ToArray();

      RepairDroid droid = new RepairDroid(program);
      return GetShortestRoute(droid).ToString();
    }

    public string SolvePartTwo(string[] input) {
      return "";
    }

    public int GetShortestRoute(RepairDroid droid) {
      int bestLength = Int32.MaxValue;
      Point position = new Point(0, 0);
      List<Point> route = new List<Point>();

      route.Add(position);
      bestLength = Math.Min(bestLength, ExploreAllDirections(droid, position, route, bestLength));

      return bestLength;
    }

    public int GetShortestRoute(RepairDroid droid, Point pos, List<Point> route, int bestLength) {
      if(route.Contains(pos)) {
        return bestLength;
      }

      route.Add(pos);
      bestLength = Math.Min(bestLength, ExploreAllDirections(droid, pos, route, bestLength));
      route.Remove(pos);

      return bestLength;
    }

    public int ExploreAllDirections(RepairDroid droid, Point origin, List<Point> route, int bestLength) {
      int l = Explore(droid, origin, route, bestLength, NORTH, SOUTH);
      bestLength = Math.Min(bestLength, l);

      l = Explore(droid, origin, route, bestLength, EAST, WEST);
      bestLength = Math.Min(bestLength, l);

      l = Explore(droid, origin, route, bestLength, SOUTH, NORTH);
      bestLength = Math.Min(bestLength, l);

      l = Explore(droid, origin, route, bestLength, WEST, EAST);
      bestLength = Math.Min(bestLength, l);

      return bestLength;
    }

    public int Explore(RepairDroid droid, Point pos, List<Point> route, int bestLength, long direction, long oppositeDirection) {
      Point move = GetNextPosition(pos, direction);
      long reply = droid.Move(direction);
      switch(reply) {
        case DEST:
          bestLength = Math.Min(route.Count, bestLength);
          droid.Move(oppositeDirection);
          break;
        case MOVE:
          int length = GetShortestRoute(droid, move, route, bestLength);
          bestLength = Math.Min(bestLength, length);
          droid.Move(oppositeDirection);
          break;
        case WALL:
          break;
      }

      return bestLength;
    }

    public Point GetNextPosition(Point position, long direction) {
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
