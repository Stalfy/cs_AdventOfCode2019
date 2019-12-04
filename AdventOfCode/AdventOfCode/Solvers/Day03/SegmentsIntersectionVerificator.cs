using System;

namespace AdventOfCode.Solvers.Day03 {
  public class SegmentsIntersectionVerificator {
    private enum Direction { Counterclockwise = -1, Colinear, Clockwise };

    public bool Verify(Point p1, Point p2, Point q1, Point q2) {
      Direction d1 = GetDirection(q1, q2, p1);
      Direction d2 = GetDirection(q1, q2, p2);
      Direction d3 = GetDirection(p1, p2, q1);
      Direction d4 = GetDirection(p1, p2, q2);

      bool pStraddlesQ = (d1 > 0 && d2 < 0) || (d1 < 0 && d2 > 0);
      bool qStraddlesP = (d3 > 0 && d4 < 0) || (d3 < 0 && d4 > 0);
      
      return pStraddlesQ && qStraddlesP;
    }

    private Direction GetDirection(Point p, Point q, Point r) {
      int crossProduct = (q.Y - p.Y) * (r.X - q.X) - (q.X - p.X) * (r.Y - q.Y);

      if (0 == crossProduct) {
        return Direction.Colinear;
      }

      return (crossProduct > 0) ? Direction.Clockwise : Direction.Counterclockwise;
    }
  }
}
