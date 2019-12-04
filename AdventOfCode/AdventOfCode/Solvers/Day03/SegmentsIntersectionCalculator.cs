using System;

namespace AdventOfCode.Solvers.Day03 {
  public class SegmentsIntersectionCalculator {
    public Point Calculate(Point p1, Point p2, Point q1, Point q2) {
      int x = p1.X;
      int y = p1.Y;

      if (p1.X != p2.X) {
        x = q1.X;
      }

      if (p1.Y != p2.Y) {
        y = q1.Y;
      }

      return new Point(x, y);
    }
  }
}
