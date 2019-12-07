using NUnit.Framework;

using AdventOfCode.Solvers.Day06;

namespace AdventOfCode.Tests {
  public class OrbitMapTests {

    [Test]
    public void TestRootOnlyChecksum() {
      OrbitMap om = new OrbitMap();
      int checksum = om.GetChecksum();
      Assert.That(checksum, Is.EqualTo(0));
    }

    [Test]
    public void TestAddDirectOrbit() {
      OrbitMap om = new OrbitMap();
      Assert.That(om.AddOrbit("COM", "A"), Is.EqualTo(true));

      int checksum = om.GetChecksum();
      Assert.That(checksum, Is.EqualTo(1));
    }

    [Test]
    public void TestAddMultipleDirectOrbit() { 
      OrbitMap om = new OrbitMap();

      Assert.That(om.AddOrbit("COM", "A"), Is.EqualTo(true));
      Assert.That(om.AddOrbit("COM", "B"), Is.EqualTo(true));

      int checksum = om.GetChecksum();
      Assert.That(checksum, Is.EqualTo(2));
    }

    [Test]
    public void TestAddIndirectOrbit() { 
      OrbitMap om = new OrbitMap();

      Assert.That(om.AddOrbit("COM", "A"), Is.EqualTo(true));
      Assert.That(om.AddOrbit("A", "B"), Is.EqualTo(true));
      Assert.That(om.AddOrbit("NOTFOUND", "B"), Is.EqualTo(false));

      int checksum = om.GetChecksum();
      Assert.That(checksum, Is.EqualTo(3));
    }

    [Test]
    public void TestAddDeepIndirectOrbit() { 
      OrbitMap om = new OrbitMap();

      Assert.That(om.AddOrbit("COM", "A"), Is.EqualTo(true));
      Assert.That(om.AddOrbit("A", "B"), Is.EqualTo(true));
      Assert.That(om.AddOrbit("B", "C"), Is.EqualTo(true));
      Assert.That(om.AddOrbit("NOTFOUND", "D"), Is.EqualTo(false));

      int checksum = om.GetChecksum();
      Assert.That(checksum, Is.EqualTo(6));
    }

    [Test]
    public void TestGetOrbitalDistance() {
      OrbitMap om = new OrbitMap();

      Assert.That(om.AddOrbit("COM", "A"), Is.EqualTo(true));
      Assert.That(om.AddOrbit("A", "B"), Is.EqualTo(true));
      Assert.That(om.AddOrbit("B", "C"), Is.EqualTo(true));
      Assert.That(om.AddOrbit("NOTFOUND", "D"), Is.EqualTo(false));

      int checksum = om.GetChecksum();
      Assert.That(checksum, Is.EqualTo(6));
    }
  }
}
