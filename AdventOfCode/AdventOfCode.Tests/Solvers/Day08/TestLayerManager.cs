using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

using AdventOfCode.Solvers.Day08;

namespace AdventOfCode.Tests {
  public class LayerManagerTests {
    
    [Test]
    public void TestCreateLayers() {
      string data = "000111000111000111";

      LayerManager lm = new LayerManager();
      List<string> layers = lm.CreateLayers(data, 3, 2).ToList();

      Assert.That(layers.Count, Is.EqualTo(3));
      Assert.That(layers[0].Length, Is.EqualTo(6));
    }
  }
}
