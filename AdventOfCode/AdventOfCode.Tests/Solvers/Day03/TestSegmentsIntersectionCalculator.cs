using NUnit.Framework;

using AdventOfCode.Solvers.Day03;

namespace AdventOfCode.Tests {
  public class SegmentsIntersectionCalculatorTests {

    [Test]
    public void TestInterectingSegments() {
      Point p1 = new Point(0, 1);
      Point p2 = new Point(3, 1);
      Point q1 = new Point(2, 0);
      Point q2 = new Point(2, 2);
      SegmentsIntersectionCalculator sic = new SegmentsIntersectionCalculator();
      Point result = sic.Calculate(p1, p2, q1, q2);

      Assert.That(result.X, Is.EqualTo(2));
      Assert.That(result.Y, Is.EqualTo(1));
    }
  }
}
