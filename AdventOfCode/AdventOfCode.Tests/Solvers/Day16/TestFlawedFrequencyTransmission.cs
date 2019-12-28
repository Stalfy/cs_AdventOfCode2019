using NUnit.Framework;

using System.Collections.Generic;
using System.Linq;

using AdventOfCode.Solvers.Day16;

namespace AdventOfCode.Tests {
  public class FlawedFrequencyTransmissionTests {
    [TestCase(2, new int[] { 1, 2, 3, 4 }, new int[] { 0, 1, 0, -1 }, 0)]
    [TestCase(5, new int[] { 1, 2, 3, 4 }, new int[] { 0, 1, 0, -1 }, 1)]
    [TestCase(7, new int[] { 1, 2, 3, 4 }, new int[] { 0, 1, 0, -1 }, 2)]
    [TestCase(4, new int[] { 1, 2, 3, 4 }, new int[] { 0, 1, 0, -1 }, 3)]
    public void TestApplyPattern(int expected, int[] signal, int[] pattern, int digit) {
      FlawedFrequencyTransmission fft = new FlawedFrequencyTransmission();
      int result = fft.ApplyPattern(signal.ToList(), pattern.ToList(), digit);
      Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(0, new int[] { 2,5,7,4 }, new int[] { 1,2,3,4 }, new int[] { 0,1,0,-1 })]
    public void TestPhase(int offset, int[] expected, int[] signal, int[] pattern) {
      FlawedFrequencyTransmission fft = new FlawedFrequencyTransmission();
      List<int> result = fft.Phase(signal.ToList(), pattern.ToList(), offset);

      for(int i = 0; i < expected.Length; i++) {
        Assert.That(result[i], Is.EqualTo(expected[i]));
      }
    }
  }
}
