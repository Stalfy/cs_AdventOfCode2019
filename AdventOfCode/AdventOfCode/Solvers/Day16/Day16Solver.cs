using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AdventOfCode.Solvers.Day16;

namespace AdventOfCode.Solvers {
  public class Day16Solver : Solver {
    public string SolvePartOne(string[] input) {
      return SolvePartOne(input, 100);
    }

    public string SolvePartOne(string[] input, int phases) {
      List<int> signal = string
        .Join("", input).ToCharArray()
        .Select(x => (int) Char.GetNumericValue(x)).ToList();

      FlawedFrequencyTransmission fft = new FlawedFrequencyTransmission();
      List<int> pattern = new List<int> { 0, 1, 0, -1 };

      for(int i = 0; i < phases; i++) {
        signal = fft.Phase(signal, pattern, 0);
      }

      return string.Join("", signal).Substring(0, 8);
    }

    public string SolvePartTwo(string[] input) {
      string str = string.Join("", input);
      int offset = Int32.Parse(str.Substring(0, 7));
      
      StringBuilder sb = new StringBuilder(str.Length * 10000);
      for(int i = 0; i < 10000; i++) {
        sb.Append(str);
      } 

      List<int> signal = sb.ToString().ToCharArray()
        .Select(x => (int) Char.GetNumericValue(x)).ToList();

      FlawedFrequencyTransmission fft = new FlawedFrequencyTransmission();
      List<int> pattern = new List<int> { 0, 1, 0, -1 };

      for(int i = 0; i < 100; i++) {
        signal = fft.Phase(signal, pattern, offset);
      }

      return string.Join("", signal).Substring(offset, 8);
    }
  }
}
