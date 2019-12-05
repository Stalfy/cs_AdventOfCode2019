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
      bool validDigitsPairPresent = false;

      bool isDigitsPair;

      string str = password.ToString();
      for (int i = 0; i < str.Length - 1; i++) {
        increasingNumberOrder &= (str[i] <= str[i + 1]);

        isDigitsPair = (str[i] == str[i + 1]);

        if (i > 0) {
          isDigitsPair &= (str[i - 1] != str[i]);
        }

        if (i < str.Length - 2) {
          isDigitsPair &= (str[i + 1] != str[i + 2]);
        }

        validDigitsPairPresent |= isDigitsPair;
      }

      return increasingNumberOrder && validDigitsPairPresent;
    }
  }
}
