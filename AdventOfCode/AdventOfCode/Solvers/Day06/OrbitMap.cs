using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solvers.Day06 {
  public class OrbitMap {
    private class Orbit {
      public int Depth { get; }
      public string Center { get; }
      public string Name { get; }
      public List<Orbit> Children { get; set; }

      public Orbit(int depth, string center, string name) {
        Depth = depth;
        Center = center;
        Name = name;
        Children = new List<Orbit>();
      }
    }

    private Orbit Root;

    public OrbitMap() {
      Root = new Orbit(0, "COM", "COM");
    }

    public bool AddOrbit(string center, string name) {

      Orbit o = GetOrbit(Root, center);
      if (null != o) {
        o.Children.Add(new Orbit(o.Depth + 1, center, name));
        return true;
      }

      return false;
    }

    private Orbit GetOrbit(Orbit o, string targetName) {
      if (o.Name == targetName) {
        return o;
      }

      List<Orbit> candidates = o.Children.Where(x => x.Name == targetName).ToList();
      if (1 == candidates.Count) {
        return candidates[0];
      }

      
      if (0 == candidates.Count && 0 != o.Children.Count) {
        foreach (Orbit child in o.Children) {
          Orbit found = GetOrbit(child, targetName);

          if (null != found) {
            return found;
          }
        }
      }

      return null;
    }

    public int GetChecksum() {
      return GetChildChecksum(Root);
    }

    private int GetChildChecksum(Orbit o) {
      int checksum = o.Depth;

      if (0 == o.Children.Count) {
        return checksum;
      }

      foreach (Orbit child in o.Children) {
        checksum += GetChildChecksum(child);
      }

      return checksum;
    }

    public int GetOrbitalDistance(string origin, string target) {
      return 0;
    }
  }
}
