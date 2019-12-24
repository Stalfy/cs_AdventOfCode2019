using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solvers.Day14 {
  public class Nanofactory {
    public List<Reaction> ParseInput(string[] input) {
      return input
        .Select(x => ParseReaction(x)).ToList();
    }

    public Reaction ParseReaction(string reaction) {
      string[] inOutSplit = reaction.Split(" => ");

      List<Chemical> inputs = inOutSplit[0].Split(", ")
        .Select(input => input.Split(" "))
        .Select(input => new Chemical(Int64.Parse(input[0]), input[1]))
        .ToList();

      string[] outputSplit = inOutSplit[1].Split(" ");
      Chemical output = new Chemical(Int64.Parse(outputSplit[0]), outputSplit[1]);

      return new Reaction(inputs, output);
    }

    public int CountDependencies(Reaction r, List<Reaction> reactions) {
      int dependencies = reactions
        .SelectMany(reaction => reaction.Inputs)
        .Count(chem => chem.Name == r.Output.Name);

      return dependencies;
    }

    public List<Reaction> Rearrange(Reaction baseReaction, List<Reaction> reactions) {
      List<string> baseInputNames = baseReaction.Inputs.Select(x => x.Name).ToList();
      return reactions
        .OrderBy(x => CountDependencies(x, reactions))
        .ToList();
    }

    public void CombineInputs(Reaction reaction) {
      reaction.Inputs = reaction.Inputs
        .GroupBy(x => x.Name)
        .Select(grp => 
            new Chemical(grp.Select(chem => chem.Units).Sum(), grp.Key))
        .ToList();
    }

    public bool CanCombine(Reaction a, Reaction b) {
      return null != a.Inputs.Find(x => x.Name == b.Output.Name);
    }

    public void CombineReactions(Reaction a, Reaction b) {
      Chemical input = a.Inputs.Find(x => x.Name == b.Output.Name);
      decimal inputUnits = Convert.ToDecimal(input.Units);
      decimal outputUnits = Convert.ToDecimal(b.Output.Units);
      long ratio = Decimal.ToInt64(Math.Ceiling(inputUnits / outputUnits));

      a.Inputs.Remove(input);
      a.Inputs.AddRange(b.Inputs.Select(x => new Chemical(x.Units * ratio, x.Name)));
      input = a.Inputs.Find(x => x.Name == b.Output.Name);
    }
  }
}
