using NUnit.Framework;

using AdventOfCode.Solvers.Day03;

namespace AdventOfCode.Tests {
  public class SegmentsIntersectionVerificatorTests {

    [Test]
    public void TestHorizontallyParallelSegments() {
      Point p1 = new Point(0, 0);
      Point p2 = new Point(2, 0);
      Point q1 = new Point(0, 1);
      Point q2 = new Point(2, 1);
      SegmentsIntersectionVerificator siv = new SegmentsIntersectionVerificator();
      bool result = siv.Verify(p1, p2, q1, q2);
      Assert.That(result, Is.EqualTo(false));
    }

    [Test]
    public void TestVerticallyParallelSegments() {
      Point p1 = new Point(0, 0);
      Point p2 = new Point(0, 2);
      Point q1 = new Point(1, 0);
      Point q2 = new Point(1, 2);
      SegmentsIntersectionVerificator siv = new SegmentsIntersectionVerificator();
      bool result = siv.Verify(p1, p2, q1, q2);
      Assert.That(result, Is.EqualTo(false));
    }

    [Test]
    public void TestP1OnSegmentQ() {
      Point p1 = new Point(1, 0);
      Point p2 = new Point(1, 2);
      Point q1 = new Point(0, 0);
      Point q2 = new Point(0, 2);
      SegmentsIntersectionVerificator siv = new SegmentsIntersectionVerificator();
      bool result = siv.Verify(p1, p2, q1, q2);
      Assert.That(result, Is.EqualTo(false));
    }

    [Test]
    public void TestP2OnSegmentQ() {
      Point p1 = new Point(1, 0);
      Point p2 = new Point(1, 2);
      Point q1 = new Point(2, 0);
      Point q2 = new Point(2, 2);
      SegmentsIntersectionVerificator siv = new SegmentsIntersectionVerificator();
      bool result = siv.Verify(p1, p2, q1, q2);
      Assert.That(result, Is.EqualTo(false));
    }

    [Test]
    public void TestQ1OnSegmentP() {
      Point p1 = new Point(0, 0);
      Point p2 = new Point(0, 2);
      Point q1 = new Point(1, 0);
      Point q2 = new Point(1, 2);
      SegmentsIntersectionVerificator siv = new SegmentsIntersectionVerificator();
      bool result = siv.Verify(p1, p2, q1, q2);
      Assert.That(result, Is.EqualTo(false));
    }

    [Test]
    public void TestQ2OnSegmentP() {
      Point p1 = new Point(2, 0);
      Point p2 = new Point(2, 2);
      Point q1 = new Point(1, 0);
      Point q2 = new Point(1, 2);
      SegmentsIntersectionVerificator siv = new SegmentsIntersectionVerificator();
      bool result = siv.Verify(p1, p2, q1, q2);
      Assert.That(result, Is.EqualTo(false));
    }

    [Test]
    public void TestInterectingSegments() {
      Point p1 = new Point(0, 1);
      Point p2 = new Point(2, 1);
      Point q1 = new Point(1, 0);
      Point q2 = new Point(1, 2);
      SegmentsIntersectionVerificator siv = new SegmentsIntersectionVerificator();
      bool result = siv.Verify(p1, p2, q1, q2);
      Assert.That(result, Is.EqualTo(true));
    }
  }
}
