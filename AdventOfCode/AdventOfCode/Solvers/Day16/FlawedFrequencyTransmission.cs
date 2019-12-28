using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solvers.Day16 {
  public class FlawedFrequencyTransmission {
    public int ApplyPattern(List<int> signal, List<int> pattern, int digit) {
      int sum = 0;
      int repeats = digit + 1;
      
      int lowBound = digit;
      int highBound = lowBound + repeats;
      int patternIdx = 1;
      while(lowBound < signal.Count) {
        for(int i = lowBound; i < highBound && i < signal.Count; i++) {
          sum += signal[i] * pattern[patternIdx];
        }

        lowBound = highBound + repeats;
        highBound = lowBound + repeats;
        patternIdx = (patternIdx + 2) % pattern.Count;
      }

      return Math.Abs(sum) % 10; 
    }

    public List<int> Phase(List<int> signal, List<int> basePattern, int offset) {
      List<int> result = new List<int>(signal);

      int secondHalf = signal.Count / 2;

      for(int i = signal.Count - 2; i >= secondHalf && i >= offset; i--) {
        result[i] = (result[i + 1] + signal[i]) % 10;
      }

      for(int i = offset; i < secondHalf; i++) {
        result[i] = ApplyPattern(signal, basePattern, i);
      }

      return result;
    }
  }
}
