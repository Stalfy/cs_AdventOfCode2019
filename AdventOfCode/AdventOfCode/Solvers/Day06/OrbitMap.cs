using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solvers.Day06 {
  public class OrbitMap {
    private class Orbit {
      public int Depth { get; }
      public Orbit Center { get; }
      public string Name { get; }
      public List<Orbit> Children { get; set; }

      public Orbit(int depth, Orbit center, string name) {
        Depth = depth;
        Center = center;
        Name = name;
        Children = new List<Orbit>();
      }
    }

    private Orbit Root;

    public OrbitMap() {
      Root = new Orbit(0, null, "COM");
    }

    public bool AddOrbit(string target, string name) {
      Orbit o = GetOrbit(Root, target);
      if (null != o) {
        o.Children.Add(new Orbit(o.Depth + 1, o, name));
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
      Orbit o = GetOrbit(Root, origin);
      List<string> originToCom = GetPathToCom(o);

      o = GetOrbit(Root, target);
      List<string> targetToCom = GetPathToCom(o);

      int targetIndex;
      for(int i = 0; i < originToCom.Count; i++) {

        targetIndex = targetToCom.IndexOf(originToCom[i]);
        if(-1 != targetIndex) {
           return i + targetIndex;
        }
      }
      
      return -1;
    }

    private List<string> GetPathToCom(Orbit o) {
      List<string> pathToCom = new List<string>();
      
      o = o.Center;
      while (null != o) {
        pathToCom.Add(o.Name);
        o = o.Center;
      }
      
      return pathToCom;
    }
  }
}
