using System;
using System.Collections.Generic;

namespace AdventOfCode.Solvers.Day14 {
  public class Reaction {
    public List<Chemical> Inputs { get; set; }
    public Chemical Output { get; set; }

    public Reaction(List<Chemical> inputs, Chemical output) {
      Inputs = inputs;
      Output = output;
    }

    public override string ToString() {
      string str = Inputs[0].ToString();

      for(int i = 1; i < Inputs.Count; i++) {
        str = string.Concat(str, ", ", Inputs[i].ToString());
      }

      return string.Concat(str, " => ", Output.ToString());
    }
  }
}
