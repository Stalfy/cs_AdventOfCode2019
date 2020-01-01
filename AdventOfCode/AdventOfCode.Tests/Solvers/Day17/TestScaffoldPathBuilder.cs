using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Drawing;

using AdventOfCode.Solvers.Day17;

namespace AdventOfCode.Tests {
  public class ScaffoldPathBuilderTests {
    [Test]
    public void TestGetInitialDirection() {
      Dictionary<Point, long> scaffolding = new Dictionary<Point, long>();
      ScaffoldPathBuilder spb = new ScaffoldPathBuilder();

      scaffolding[new Point(1, 1)] = 94;
      Assert.That(spb.GetInitialDirection(scaffolding),
          Is.EqualTo(ScaffoldPathBuilder.Direction.Up));

      scaffolding[new Point(1, 1)] = 118;
      Assert.That(spb.GetInitialDirection(scaffolding),
          Is.EqualTo(ScaffoldPathBuilder.Direction.Down));

      scaffolding[new Point(1, 1)] = 60;
      Assert.That(spb.GetInitialDirection(scaffolding),
          Is.EqualTo(ScaffoldPathBuilder.Direction.Left));

      scaffolding[new Point(1, 1)] = 62;
      Assert.That(spb.GetInitialDirection(scaffolding),
          Is.EqualTo(ScaffoldPathBuilder.Direction.Right));
    }

    [Test]
    public void TestIsLeftPositionScaffolding() {
      Dictionary<Point, long> scaffolding = new Dictionary<Point, long>();
      ScaffoldPathBuilder spb = new ScaffoldPathBuilder();
      Point pos = new Point(0, 0);

      bool isScaffolding = spb.IsLeftPositionScaffolding(scaffolding, pos);
      Assert.That(isScaffolding, Is.EqualTo(false));

      scaffolding[new Point(-1, 0)] = 35;
      isScaffolding = spb.IsLeftPositionScaffolding(scaffolding, pos);
      Assert.That(isScaffolding, Is.EqualTo(true));
    }

    [Test]
    public void TestIsUpPositionScaffolding() {
      Dictionary<Point, long> scaffolding = new Dictionary<Point, long>();
      ScaffoldPathBuilder spb = new ScaffoldPathBuilder();
      Point pos = new Point(0, 0);

      bool isScaffolding = spb.IsUpPositionScaffolding(scaffolding, pos);
      Assert.That(isScaffolding, Is.EqualTo(false));

      scaffolding[new Point(0, -1)] = 35;
      isScaffolding = spb.IsUpPositionScaffolding(scaffolding, pos);
      Assert.That(isScaffolding, Is.EqualTo(true));
    }

    [Test]
    public void TestIsRightPositionScaffolding() {
      Dictionary<Point, long> scaffolding = new Dictionary<Point, long>();
      ScaffoldPathBuilder spb = new ScaffoldPathBuilder();
      Point pos = new Point(0, 0);

      bool isScaffolding = spb.IsRightPositionScaffolding(scaffolding, pos);
      Assert.That(isScaffolding, Is.EqualTo(false));

      scaffolding[new Point(1, 0)] = 35;
      isScaffolding = spb.IsRightPositionScaffolding(scaffolding, pos);
      Assert.That(isScaffolding, Is.EqualTo(true));
    }

    [Test]
    public void TestIsDownPositionScaffolding() {
      Dictionary<Point, long> scaffolding = new Dictionary<Point, long>();
      ScaffoldPathBuilder spb = new ScaffoldPathBuilder();
      Point pos = new Point(0, 0);

      bool isScaffolding = spb.IsDownPositionScaffolding(scaffolding, pos);
      Assert.That(isScaffolding, Is.EqualTo(false));

      scaffolding[new Point(0, 1)] = 35;
      isScaffolding = spb.IsDownPositionScaffolding(scaffolding, pos);
      Assert.That(isScaffolding, Is.EqualTo(true));
    }

    [Test]
    public void TestCanTurnLeft() {
      Dictionary<Point, long> scaffolding = new Dictionary<Point, long>();
      ScaffoldPathBuilder spb = new ScaffoldPathBuilder();

      Point pos = new Point(0, 0);
      scaffolding[new Point(-1, 0)] = 35;

      bool canTurn = spb.CanTurnLeft(scaffolding, pos, ScaffoldPathBuilder.Direction.Up);
      Assert.That(canTurn, Is.EqualTo(true));

      canTurn = spb.CanTurnLeft(scaffolding, pos, ScaffoldPathBuilder.Direction.Left);
      Assert.That(canTurn, Is.EqualTo(false));

      canTurn = spb.CanTurnLeft(scaffolding, pos, ScaffoldPathBuilder.Direction.Down);
      Assert.That(canTurn, Is.EqualTo(false));

      canTurn = spb.CanTurnLeft(scaffolding, pos, ScaffoldPathBuilder.Direction.Right);
      Assert.That(canTurn, Is.EqualTo(false));
    }

    [Test]
    public void TestCanTurnRight() {
      Dictionary<Point, long> scaffolding = new Dictionary<Point, long>();
      ScaffoldPathBuilder spb = new ScaffoldPathBuilder();

      Point pos = new Point(0, 0);
      scaffolding[new Point(1, 0)] = 35;

      bool can = spb.CanTurnRight(scaffolding, pos, ScaffoldPathBuilder.Direction.Up);
      Assert.That(can, Is.EqualTo(true));

      can = spb.CanTurnRight(scaffolding, pos, ScaffoldPathBuilder.Direction.Left);
      Assert.That(can, Is.EqualTo(false));

      can = spb.CanTurnRight(scaffolding, pos, ScaffoldPathBuilder.Direction.Down);
      Assert.That(can, Is.EqualTo(false));

      can = spb.CanTurnRight(scaffolding, pos, ScaffoldPathBuilder.Direction.Right);
      Assert.That(can, Is.EqualTo(false));
    }

    [Test]
    public void TestCanGoForward() {
      Dictionary<Point, long> scaffolding = new Dictionary<Point, long>();
      ScaffoldPathBuilder spb = new ScaffoldPathBuilder();

      Point pos = new Point(0, 0);
      scaffolding[new Point(0, -1)] = 35;

      bool can = spb.CanGoForward(scaffolding, pos, ScaffoldPathBuilder.Direction.Up);
      Assert.That(can, Is.EqualTo(true));

      can = spb.CanGoForward(scaffolding, pos, ScaffoldPathBuilder.Direction.Left);
      Assert.That(can, Is.EqualTo(false));

      can = spb.CanGoForward(scaffolding, pos, ScaffoldPathBuilder.Direction.Down);
      Assert.That(can, Is.EqualTo(false));

      can = spb.CanGoForward(scaffolding, pos, ScaffoldPathBuilder.Direction.Right);
      Assert.That(can, Is.EqualTo(false));
    }

    [Test]
    public void TestMove() {
      Dictionary<Point, long> scaffolding = new Dictionary<Point, long>();
      ScaffoldPathBuilder spb = new ScaffoldPathBuilder();

      Point pos = new Point(0, 0);

      pos = spb.Move(pos, ScaffoldPathBuilder.Direction.Up);
      Assert.That(pos.Y, Is.EqualTo(-1));

      pos = spb.Move(pos, ScaffoldPathBuilder.Direction.Down);
      Assert.That(pos.Y, Is.EqualTo(0));

      pos = spb.Move(pos, ScaffoldPathBuilder.Direction.Left);
      Assert.That(pos.X, Is.EqualTo(-1));

      pos = spb.Move(pos, ScaffoldPathBuilder.Direction.Right);
      Assert.That(pos.X, Is.EqualTo(0));
    }

    [Test]
    public void TestTurnLeft() {
      Dictionary<Point, long> scaffolding = new Dictionary<Point, long>();
      ScaffoldPathBuilder spb = new ScaffoldPathBuilder();
      ScaffoldPathBuilder.Direction dir = ScaffoldPathBuilder.Direction.Up;

      dir = spb.TurnLeft(dir);
      Assert.That(dir, Is.EqualTo(ScaffoldPathBuilder.Direction.Left));

      dir = spb.TurnLeft(dir);
      Assert.That(dir, Is.EqualTo(ScaffoldPathBuilder.Direction.Down));

      dir = spb.TurnLeft(dir);
      Assert.That(dir, Is.EqualTo(ScaffoldPathBuilder.Direction.Right));

      dir = spb.TurnLeft(dir);
      Assert.That(dir, Is.EqualTo(ScaffoldPathBuilder.Direction.Up));
    }

    [Test]
    public void TestTurnRight() {
      Dictionary<Point, long> scaffolding = new Dictionary<Point, long>();
      ScaffoldPathBuilder spb = new ScaffoldPathBuilder();
      ScaffoldPathBuilder.Direction dir = ScaffoldPathBuilder.Direction.Up;

      dir = spb.TurnRight(dir);
      Assert.That(dir, Is.EqualTo(ScaffoldPathBuilder.Direction.Right));

      dir = spb.TurnRight(dir);
      Assert.That(dir, Is.EqualTo(ScaffoldPathBuilder.Direction.Down));

      dir = spb.TurnRight(dir);
      Assert.That(dir, Is.EqualTo(ScaffoldPathBuilder.Direction.Left));

      dir = spb.TurnRight(dir);
      Assert.That(dir, Is.EqualTo(ScaffoldPathBuilder.Direction.Up));
    }

    [Test]
    public void TestConvertStepsToAscii() {
      ScaffoldPathBuilder spb = new ScaffoldPathBuilder();
      List<long> result = spb.ConvertStepsToAscii(123);
      
      Assert.That(result[0], Is.EqualTo('0' + 1));
      Assert.That(result[1], Is.EqualTo('0' + 2));
      Assert.That(result[2], Is.EqualTo('0' + 3));
    }

    [Test]
    public void TestMoveForward() {
      Dictionary<Point, long> scaffolding = new Dictionary<Point, long>();
      ScaffoldPathBuilder spb = new ScaffoldPathBuilder();

      Point pos = new Point(0, 0);
      ScaffoldPathBuilder.Direction dir = ScaffoldPathBuilder.Direction.Up;

      scaffolding[new Point(0, -1)] = 35;
      scaffolding[new Point(0, -2)] = 35;
      scaffolding[new Point(0, -3)] = 35;
      scaffolding[new Point(0, -4)] = 35;
    
      long steps = spb.MoveForward(scaffolding, ref pos, dir);
      Assert.That(steps, Is.EqualTo(4));
      Assert.That(pos.X, Is.EqualTo(0));
      Assert.That(pos.Y, Is.EqualTo(-4));
    }
  }
}
