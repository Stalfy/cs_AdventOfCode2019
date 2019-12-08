using System;
using System.Collections.Generic;

namespace AdventOfCode.Solvers.Day08 {
  public class LayerManager {
    public IEnumerable<string> CreateLayers(string data, int width, int height) {
      int layerLength = width * height;
      for(int i = 0; i < data.Length; i += layerLength) {
        yield return data.Substring(i, layerLength);
      } 
    }
  }
}
