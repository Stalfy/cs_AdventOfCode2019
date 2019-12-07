using System;
using System.Collections.Generic;
using System.Linq;

using AdventOfCode.Solvers.Day06;

namespace AdventOfCode.Solvers {
  public class Day06Solver : Solver {

    public string SolvePartOne(string[] input) {
      List<string[]> orbits = input.Select(x => x.Split(")")).ToList();
      OrbitMap om = PopulateOrbitMap(orbits);

      return om.GetChecksum().ToString();
    }

    public string SolvePartTwo(string[] input) {
      return "";
    }

    private OrbitMap PopulateOrbitMap(List<string[]> orbits) {
      OrbitMap om = new OrbitMap();
      while (0 != orbits.Count) {
        int i = 0;

        while(i < orbits.Count) {
          if(om.AddOrbit(orbits[i][0], orbits[i][1])) {
            orbits.RemoveAt(i);
          } else {
            i++;
          }
        }
      }

      return om;
    }
  }
}
