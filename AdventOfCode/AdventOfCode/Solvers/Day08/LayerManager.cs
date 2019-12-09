using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solvers.Day08 {
  public class LayerManager {
    public IEnumerable<string> CreateLayers(string data, int width, int height) {
      int layerLength = width * height;
      for(int i = 0; i < data.Length; i += layerLength) {
        yield return data.Substring(i, layerLength);
      } 
    }

    public string FlattenLayers(List<string> layers) {
      StringBuilder sb = new StringBuilder(layers[0]);

      for(int i = 0; i < sb.Length; i++) {
        for(int j = 1; '2' == sb[i] && j < layers.Count; j++) {
          sb[i] = layers[j][i];
        }
      }

      return sb.ToString();
    }

    public List<string> FormatLayer(string layer, int width) {
      List<string> output = new List<string>();

      layer = layer.Replace('0', '\u2B2D');
      layer = layer.Replace('1', '\u2B2C');

      for(int i = 0; i < layer.Length; i += width) {
        output.Add(layer.Substring(i, width));
      }

      return output;
    }
  }
}
