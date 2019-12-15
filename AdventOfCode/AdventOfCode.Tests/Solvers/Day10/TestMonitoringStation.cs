using System;
using NUnit.Framework;

using AdventOfCode.Solvers.Day10;

namespace AdventOfCode.Tests {
  public class MonitoringStationTests {
    [TestCase(5.000, 0.001, new double[] { 0, 0, 3, 4 })]
    [TestCase(9.486, 0.001, new double[] { 0, 0, 3, 9 })]
    public void TestDistance(double expected, double tol, double[] coord) {
      MonitoringStation ms = new MonitoringStation();
      double d = ms.Distance(coord[0], coord[1], coord[2], coord[3]);
      Assert.That(Math.Abs(d - expected) <= tol, Is.EqualTo(true));
    }

    [TestCase(1.570, 0.001, new double[] { 0, 0, 0, 4 })]
    [TestCase(3.14159, 0.001, new double[] { 0, 0, -3, 0 })]
    public void TestAngle(double expected, double tol, double[] coord) {
      MonitoringStation ms = new MonitoringStation();
      double a = ms.Angle(coord[0], coord[1], coord[2], coord[3]);
      Console.WriteLine(a);
      Assert.That(Math.Abs(a - expected) <= tol, Is.EqualTo(true));
    }

  }
}
