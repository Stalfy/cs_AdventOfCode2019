using System;

using AdventOfCode.Solvers.Day04;

namespace AdventOfCode.Solvers {
  public class Day04Solver : Solver {

    public string SolvePartOne(string[] input) {
      string[] range = input[0].Split("-");
      int validPasswords = 0;

      PasswordScanner ps = new PasswordScanner();
      for(int i = Int32.Parse(range[0]); i <= Int32.Parse(range[1]); i++) {
        if(ps.IsValidPassword(i)) {
          validPasswords++;
        }
      }

      return validPasswords.ToString();
    }

    public string SolvePartTwo(string[] input) {
      return "";
    }
  }
}
