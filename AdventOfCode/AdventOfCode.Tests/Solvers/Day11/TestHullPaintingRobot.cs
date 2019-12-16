using NUnit.Framework;

using AdventOfCode.Solvers.Day11;

namespace AdventOfCode.Tests {
  public class HullPaintingRobotTests {
    [Test]
    public void TestRotateClockwise() {
      HullPaintingRobot hpr = new HullPaintingRobot(new long[10]);

      Assert.That(hpr.Direction, Is.EqualTo(0));
      hpr.Rotate(1);
      Assert.That(hpr.Direction, Is.EqualTo(1));
      hpr.Rotate(1);
      Assert.That(hpr.Direction, Is.EqualTo(2));
      hpr.Rotate(1);
      Assert.That(hpr.Direction, Is.EqualTo(3));
      hpr.Rotate(1);
      Assert.That(hpr.Direction, Is.EqualTo(0));
    }

    [Test]
    public void TestRotateCounterClockwise() {
      HullPaintingRobot hpr = new HullPaintingRobot(new long[10]);

      Assert.That(hpr.Direction, Is.EqualTo(0));
      hpr.Rotate(0);
      Assert.That(hpr.Direction, Is.EqualTo(3));
      hpr.Rotate(0);
      Assert.That(hpr.Direction, Is.EqualTo(2));
      hpr.Rotate(0);
      Assert.That(hpr.Direction, Is.EqualTo(1));
      hpr.Rotate(0);
      Assert.That(hpr.Direction, Is.EqualTo(0));
    }

    [Test]
    public void TestMoveUp() {
      HullPaintingRobot hpr = new HullPaintingRobot(new long[10]);
      hpr.Move();
      Assert.That(hpr.X, Is.EqualTo(0));
      Assert.That(hpr.Y, Is.EqualTo(-1));
    }

    [Test]
    public void TestMoveRight() {
      HullPaintingRobot hpr = new HullPaintingRobot(new long[10]);
      hpr.Rotate(1);
      hpr.Move();
      Assert.That(hpr.X, Is.EqualTo(1));
      Assert.That(hpr.Y, Is.EqualTo(0));
    }

    [Test]
    public void TestMoveDown() {
      HullPaintingRobot hpr = new HullPaintingRobot(new long[10]);
      hpr.Rotate(1);
      hpr.Rotate(1);
      hpr.Move();
      Assert.That(hpr.X, Is.EqualTo(0));
      Assert.That(hpr.Y, Is.EqualTo(1));
    }

    [Test]
    public void TestMoveLeft() {
      HullPaintingRobot hpr = new HullPaintingRobot(new long[10]);
      hpr.Rotate(0);
      hpr.Move();
      Assert.That(hpr.X, Is.EqualTo(-1));
      Assert.That(hpr.Y, Is.EqualTo(0));
    }
  }
}
