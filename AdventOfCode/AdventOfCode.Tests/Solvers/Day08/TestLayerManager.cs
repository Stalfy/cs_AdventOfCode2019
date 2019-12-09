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

    [Test]
    public void TestFlattenLayers() {
      List<string> layers = new List<string>();
      layers.Add("0222");
      layers.Add("1122");
      layers.Add("2212");
      layers.Add("0000");

      LayerManager lm = new LayerManager();
      string layer = lm.FlattenLayers(layers);

      Assert.That(layer, Is.EqualTo("0110"));
    }

    [Test]
    public void TestFormatLayer() {
      string layer = "0110";
      
      LayerManager lm = new LayerManager();
      List<string> output = lm.FormatLayer(layer, 2);

      Assert.That(output[0], Is.EqualTo("⬭⬬"));
      Assert.That(output[1], Is.EqualTo("⬬⬭"));
    }
  }
}
