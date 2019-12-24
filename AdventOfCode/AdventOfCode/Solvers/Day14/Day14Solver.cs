using System;
using System.Collections.Generic;
using System.Linq;

using AdventOfCode.Solvers.Day14;

namespace AdventOfCode.Solvers {
  public class Day14Solver : Solver {

    public string SolvePartOne(string[] input) {
      Nanofactory n = new Nanofactory();
      List<Reaction> reactions = n.ParseInput(input);

      Reaction fuelR = reactions.Find(x => x.Output.Name == "FUEL");
      reactions.Remove(fuelR);

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

      return fuelR.Inputs[0].Units.ToString();
    }

    public string SolvePartTwo(string[] input) {
      return "";
    }
  }
}
