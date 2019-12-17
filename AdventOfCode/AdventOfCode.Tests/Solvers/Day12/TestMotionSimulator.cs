using System.Collections.Generic;

using NUnit.Framework;

using AdventOfCode.Solvers.Day12;

namespace AdventOfCode.Tests {
  public class MotionSimulatorTests {
    [Test]
    public void TestSimulate() {
      MotionSimulator ms = new MotionSimulator();
      
      Moon A = new Moon(-1, 0, 2);
      Moon B = new Moon(2, -10, -7);
      Moon C = new Moon(4, -8, 8);
      Moon D = new Moon(3, 5, -1);

      List<Moon> moons = new List<Moon>();
      moons.Add(A);
      moons.Add(B);
      moons.Add(C);
      moons.Add(D);

      ms.Simulate(moons, 10);
      
      Assert.That(A.PosX, Is.EqualTo(2));
      Assert.That(A.PosY, Is.EqualTo(1));
      Assert.That(A.PosZ, Is.EqualTo(-3));
      Assert.That(A.VelX, Is.EqualTo(-3));
      Assert.That(A.VelY, Is.EqualTo(-2));
      Assert.That(A.VelZ, Is.EqualTo(1));
    }

    [Test]
    public void TestUpdateVelocity() {
      MotionSimulator ms = new MotionSimulator();

      Moon A = new Moon(0, 0, 0);
      Moon B = new Moon(1, 1, 1);

      List<Moon> moons = new List<Moon>(2);
      moons.Add(A);
      moons.Add(B);

      ms.UpdateVelocity(moons);

      Assert.That(A.VelX, Is.EqualTo(1));
      Assert.That(A.VelY, Is.EqualTo(1));
      Assert.That(A.VelZ, Is.EqualTo(1));
      Assert.That(B.VelX, Is.EqualTo(-1));
      Assert.That(B.VelY, Is.EqualTo(-1));
      Assert.That(B.VelZ, Is.EqualTo(-1));
    }

    [Test]
    public void TestUpdatePosition() {
      MotionSimulator ms = new MotionSimulator();

      Moon A = new Moon(0, 0, 0);
      A.VelX = 1;
      A.VelY = 2;
      A.VelZ = 3;
      List<Moon> moons = new List<Moon>();
      moons.Add(A);

      ms.UpdatePosition(moons);

      Assert.That(A.VelX, Is.EqualTo(1));
      Assert.That(A.VelY, Is.EqualTo(2));
      Assert.That(A.VelZ, Is.EqualTo(3));
    }
  }
}
