using System;

namespace AdventOfCode.Solvers.Day04 {
  public class PasswordScanner {
    public bool IsPasswordValid(int password) {
      bool increasingNumberOrder = true;
      bool digitsPairPresent = false;

      foreach (char c in password.ToString()) {
        Console.WriteLine(c);
      }
    
      return increasingNumberOrder && digitsPairPresent;
    }
  }
}
