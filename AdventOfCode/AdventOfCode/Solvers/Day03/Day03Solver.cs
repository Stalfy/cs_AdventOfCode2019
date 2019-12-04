using System;
using System.Collections.Generic;

using AdventOfCode.Solvers.Day03;

namespace AdventOfCode.Solvers {
  public class Day03Solver : Solver {

    public string SolvePartOne(string[] input) {
      List<Point> wire1Points = ParsePoints(input[0]);
      List<Point> wire2Points = ParsePoints(input[1]);
      List<Point> intersections = GetIntersections(wire1Points, wire2Points);     

      int lowestDistance = Int32.MaxValue;
      foreach (Point p in intersections) {
        lowestDistance = Math.Min(lowestDistance, Math.Abs(p.X) + Math.Abs(p.Y));
      }

      return lowestDistance.ToString();
    }

    public string SolvePartTwo(string[] input) {
      List<Point> wire1Points = ParsePoints(input[0]);
      List<Point> wire2Points = ParsePoints(input[1]);
      List<Point> intersections = GetIntersections(wire1Points, wire2Points);     

      int d1 = 0;
      int d2 = 0;
      int lowestSteps = Int32.MaxValue;
      foreach (Point p in intersections) {
       d1 = GetWireStepsFromIntersection(p, wire1Points);
       d2 = GetWireStepsFromIntersection(p, wire2Points);
       lowestSteps = Math.Min(lowestSteps, d1 + d2);
      }

      return lowestSteps.ToString();
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

    private List<Point> GetIntersections(List<Point> wire1, List<Point> wire2) {
      List<Point> intersections = new List<Point>();

      Point p1;
      Point p2;
      Point q1;
      Point q2;

      SegmentsIntersectionVerificator siv = new SegmentsIntersectionVerificator();
      SegmentsIntersectionCalculator sic = new SegmentsIntersectionCalculator();

      for(int i = 0; i < wire1.Count - 1; i++) {
        p1 = wire1[i];
        p2 = wire1[i + 1];

        for(int j = 0; j < wire2.Count - 1; j++) {
          q1 = wire2[j];
          q2 = wire2[j + 1];

          if(siv.Verify(p1, p2, q1, q2)) {
            intersections.Add(sic.Calculate(p1, p2, q1, q2));
          }
        }
      }

      return intersections;
    }

    private int GetWireStepsFromIntersection(Point q, List<Point> points) {
      int i = 0;
      int steps = 0;

      Point p1 = points[i];
      Point p2 = points[i + 1];
      while (i < points.Count - 1 && false == IsIntersectionOnSegment(q, p1, p2)) {
         steps += Math.Abs(p2.X - p1.X) + Math.Abs(p2.Y - p1.Y);
         i++;
         p1 = points[i];
         p2 = points[i + 1];
      }

      return steps + Math.Abs(q.X - p1.X) + Math.Abs(q.Y - p1.Y);
    }

    private bool IsIntersectionOnSegment(Point q, Point p1, Point p2) {
      if (q.X == p1.X && q.X == p2.X && p1.Y < q.Y && q.Y < p2.Y) {
        return true;
      }
      
      if (q.X == p1.X && q.X == p2.X && p1.Y > q.Y && q.Y > p2.Y) {
        return true;
      }
      
      if (q.Y == p1.Y && q.Y == p2.Y && p1.X < q.X && q.X < p2.X) {
        return true;
      }
      
      if (q.Y == p1.Y && q.Y == p2.Y && p1.X > q.X && q.X > p2.X) {
        return true;
      }

      return false;
    }
  }
}
