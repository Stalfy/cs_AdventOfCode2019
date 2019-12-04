using System;
using System.Collections.Generic;

using AdventOfCode.Solvers.Day03;

namespace AdventOfCode.Solvers {
  public class Day03Solver : Solver {

    public string SolvePartOne(string[] input) {
      List<Point> wire1Points = ParsePoints(input[0]);
      List<Point> wire2Points = ParsePoints(input[1]);
      List<Point> intersections = new List<Point>();

      Point p1;
      Point p2;
      Point q1;
      Point q2;

      SegmentsIntersectionVerificator siv = new SegmentsIntersectionVerificator();
      SegmentsIntersectionCalculator sic = new SegmentsIntersectionCalculator();

      for(int i = 0; i < wire1Points.Count - 1; i++) {
        p1 = wire1Points[i];
        p2 = wire1Points[i + 1];

        for(int j = 0; j < wire2Points.Count - 1; j++) {
          q1 = wire2Points[j];
          q2 = wire2Points[j + 1];

          if(siv.Verify(p1, p2, q1, q2)) {
            intersections.Add(sic.Calculate(p1, p2, q1, q2));
          }
        }
      }
      
      int lowestDistance = Int32.MaxValue;
      foreach (Point p in intersections) {
        lowestDistance = Math.Min(lowestDistance, Math.Abs(p.X) + Math.Abs(p.Y));
      }

      return lowestDistance.ToString();
    }

    public string SolvePartTwo(string[] input) {
      return 1.ToString();
    }

    private List<Point> ParsePoints(string wirePath) {
      Dictionary<char, Action<int[], int>> ops = new Dictionary<char, Action<int[], int>>(1);
      ops.Add('U', ActionAlterCoordinatesUp);
      ops.Add('D', ActionAlterCoordinatesDown);
      ops.Add('L', ActionAlterCoordinatesLeft);
      ops.Add('R', ActionAlterCoordinatesRight);

      string[] directions = wirePath.Split(",");
      List<Point> points = new List<Point>(1 + directions.Length);
      int[] coordinates = new int[2];

      points.Add(new Point(0, 0));

      char dir;
      int steps;
      foreach (string direction in directions) {
        dir = direction[0];
        steps = Int32.Parse(direction.Substring(1, direction.Length - 1));

        ops[dir](coordinates, steps);
        points.Add(new Point(coordinates[0], coordinates[1]));
      }

      return points;
    }

    private void ActionAlterCoordinatesUp(int[] coordinates, int steps) {
      coordinates[1] += steps;
    }

    private void ActionAlterCoordinatesDown(int[] coordinates, int steps) {
      coordinates[1] -= steps;
    }

    private void ActionAlterCoordinatesLeft(int[] coordinates, int steps) {
      coordinates[0] -= steps;
    }

    private void ActionAlterCoordinatesRight(int[] coordinates, int steps) {
      coordinates[0] += steps;
    }
  }
}
