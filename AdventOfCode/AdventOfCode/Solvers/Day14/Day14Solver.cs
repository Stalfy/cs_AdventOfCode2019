using System;
using System.Collections.Generic;
using System.Linq;

using AdventOfCode.Solvers.Day14;

namespace AdventOfCode.Solvers {
  public class Day14Solver : Solver {
    public string SolvePartOne(string[] input) {
      return CountRequiredOres(1, input).ToString();
    }

    public string SolvePartTwo(string[] input) {
      long previousFuel = 0;
      long requiredFuel = 1;

      while(CountRequiredOres(requiredFuel, input) < 1e12) {
        previousFuel = requiredFuel;
        requiredFuel *= 2;
      }

      return FindRequiredFuel(previousFuel, requiredFuel, input).ToString();
    }

    private long FindRequiredFuel(long minFuel, long maxFuel, string[] input) {
      if(CountRequiredOres(minFuel + 1, input) > 1e12) {
        return minFuel;
      }

      long midFuel = minFuel + ((maxFuel - minFuel) / 2);

      if(CountRequiredOres(midFuel, input) > 1e12) {
        return FindRequiredFuel(minFuel, midFuel, input);
      }
      
      return FindRequiredFuel(midFuel, maxFuel, input);
    }

    private long CountRequiredOres(long requiredFuel, string[] input) {
      Nanofactory n = new Nanofactory();
      List<Reaction> reactions = n.ParseInput(input);

      Reaction fuelR = reactions.Find(x => x.Output.Name == "FUEL");
      reactions.Remove(fuelR);

      fuelR.Output.Units *= requiredFuel;
      fuelR.Inputs.ForEach(i => i.Units *= requiredFuel);

      while (reactions.Count > 0) {
        for(int i = 0; i < reactions.Count; ) {
          Reaction r = reactions[i];

          if(n.CanCombine(fuelR, r) && n.CountDependencies(r, reactions) == 0) {
            n.CombineReactions(fuelR, r);
            n.CombineInputs(fuelR);
            reactions.RemoveAt(i);
          } else {
            i++;
          }
        }
      }

      return fuelR.Inputs[0].Units;
    }
  }
}
