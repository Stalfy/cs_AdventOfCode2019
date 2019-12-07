using System;
using System.Collections.Generic;
using System.Linq;

using AdventOfCode.Solvers.Day06;

namespace AdventOfCode.Solvers {
  public class Day06Solver : Solver {

    public string SolvePartOne(string[] input) {
      List<string[]> orbits = input.Select(x => x.Split(")")).ToList();
      OrbitMap om = new OrbitMap();
      om = PopulateOrbitMap("COM", om, orbits);

      return om.GetChecksum().ToString();
    }

    public string SolvePartTwo(string[] input) {
      return "";
    }

    private OrbitMap PopulateOrbitMap(string oName, OrbitMap om, List<string[]> orbits) {
      List<string[]> availableOrbits = orbits.Where(x => oName == x[0]).ToList();

      foreach (string[] orbit in availableOrbits) {
          om.AddOrbit(orbit[0], orbit[1]);
          PopulateOrbitMap(orbit[1], om, orbits);
          orbits.Remove(orbit);
      }

      return om;
    }


  }
}
