using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solvers {
  public class Day00Solver : Solver {
    public string SolvePartOne(string[] input) {
      string haystack = string.Join("", input);
      string needle = "(";

      int upCount = haystack.Length - haystack.Replace(needle, "").Length;
      int downCount = haystack.Length - upCount;

      return (upCount - downCount).ToString();
    }

    public string SolvePartTwo(string[] input) {
      string str = string.Join("", input);
      int i = 1;

      Regex regex = new Regex(Regex.Escape("()"));

      while(')' != str[0]) {
        str = regex.Replace(str, "", 1);
        i += 2;
      }

      return i.ToString();
    }
  }
}
