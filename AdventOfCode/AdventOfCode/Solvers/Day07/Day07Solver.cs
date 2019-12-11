using System;
using System.Collections.Generic;
using System.Linq;

using AdventOfCode.Computer;

namespace AdventOfCode.Solvers {
  public class Day07Solver : Solver {

    public string SolvePartOne(string[] input) {
      List<string> permutations = new List<string>();
      GetPermutations("01234", "", permutations);

      long maxOutput = -1;
      long[] program = input[0].Split(",").Select(x => Int64.Parse(x)).ToArray();
      foreach (string permutation in permutations) {
        maxOutput = Math.Max(maxOutput, Amplify(permutation, program));
      }

      return maxOutput.ToString();
    }

    public string SolvePartTwo(string[] input) {
      List<string> permutations = new List<string>();
      GetPermutations("56789", "", permutations);

      long maxOutput = -1;
      long[] program = input[0].Split(",").Select(x => Int64.Parse(x)).ToArray();
      foreach (string permutation in permutations) {
        maxOutput = Math.Max(maxOutput, Amplify(permutation, program));
      }

      return maxOutput.ToString();
    }

    private void GetPermutations(string str, string perm, List<string> perms) {
      if(5 == perm.Length && -1 == perms.IndexOf(perm)) {
        perms.Add(perm);
      } else {
        for(int i = 0; i < str.Length; i++) {
          string next = (string) perm.Clone() + str[i];
          GetPermutations(str.Remove(i, 1), next, perms);
        }
      }
    }

    private long Amplify(string phases, long[] program) {
      IntcodeComputer ampA = new Amplifier((long[]) program.Clone(), (long) Char.GetNumericValue(phases[0]));
      IntcodeComputer ampB = new Amplifier((long[]) program.Clone(), (long) Char.GetNumericValue(phases[1]));
      IntcodeComputer ampC = new Amplifier((long[]) program.Clone(), (long) Char.GetNumericValue(phases[2]));
      IntcodeComputer ampD = new Amplifier((long[]) program.Clone(), (long) Char.GetNumericValue(phases[3]));
      IntcodeComputer ampE = new Amplifier((long[]) program.Clone(), (long) Char.GetNumericValue(phases[4]));

      ampA.Input = 0;
      while (ampE.CurrentState != IntcodeComputer.State.Halted) {
        ampA.Run();

        ampB.Input = ampA.Output;
        ampB.Run();

        ampC.Input = ampB.Output;
        ampC.Run();

        ampD.Input = ampC.Output;
        ampD.Run();

        ampE.Input = ampD.Output;
        ampE.Run();

        ampA.Input = ampE.Output;
      }

      return ampE.Output;
    }
  }
}
