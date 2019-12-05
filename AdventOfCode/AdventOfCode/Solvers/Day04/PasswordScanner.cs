using System;

namespace AdventOfCode.Solvers.Day04 {
  public class PasswordScanner {
    public bool IsValidPassword(int password) {
      bool increasingNumberOrder = true;
      bool digitsPairPresent = false;

      string str = password.ToString();
      for (int i = 0; i < str.Length - 1; i++) {
        increasingNumberOrder &= (str[i] <= str[i + 1]);
        digitsPairPresent |= (str[i] == str[i + 1]);
      }
    
      return increasingNumberOrder && digitsPairPresent;
    }

    public bool IsValidPassword2(int password) {
      bool increasingNumberOrder = true;
      bool digitsPairPresent = false;

      string str = password.ToString();
      Console.WriteLine(str.Length);
      for (int i = 0; i < str.Length - 1; i++) {
        increasingNumberOrder &= (str[i] <= str[i + 1]);

        digitsPairPresent |= (i == str.Length - 1 && str[i] == str[i + 1]);
        digitsPairPresent |= (i < str.Length - 2
            && str[i] == str[i + 1]
            && str[i] != str[i + 2]);
      }
    
      return increasingNumberOrder && digitsPairPresent;
    }
  }
}
