using System;
using System.Collections.Generic;
using System.Linq;

using AdventOfCode.Solvers.Day08;

namespace AdventOfCode.Solvers {
  public class Day08Solver : Solver {

    public string SolvePartOne(string[] input) {
      return SolvePartOne(input, 25, 6);
    }

    public string SolvePartOne(string[] input, int width, int height) {
      string data = input[0];

      LayerManager lm = new LayerManager();
      string layer = lm.CreateLayers(data, width, height)
        .OrderBy(layer => layer.Length - layer.Replace("0", "").Length)
        .ToList()[0];

      int ones = layer.Length - layer.Replace("1", "").Length;
      int twos = layer.Length - layer.Replace("2", "").Length;

      return (ones * twos).ToString();
    }

    public string SolvePartTwo(string[] input) {
      return SolvePartTwo(input, 25, 6);
    }

    public string SolvePartTwo(string[] input, int width, int height) {
      string data = input[0];

      LayerManager lm = new LayerManager();
      List<string> layers = lm.CreateLayers(data, width, height).ToList();
      string flatLayer = lm.FlattenLayers(layers);
      List<string> output = lm.FormatLayer(flatLayer, width);

      return "\n" + string.Join("\n", output);
    }
  }
}
