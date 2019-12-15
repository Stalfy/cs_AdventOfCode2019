using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solvers.Day10 {
  public class MonitoringStation {
    public MonitoringStation() {}

    public Asteroid FindBestAsteroid(List<Asteroid> asteroids, out int bestDlosCount) {
      Asteroid bestAsteroid = new Asteroid(-1, -1);
      bestDlosCount = 0;

      int dlosCount = 0;
      foreach (Asteroid candidate in asteroids) {
        dlosCount = CountDLOS(candidate, asteroids);

        if(dlosCount > bestDlosCount) {
          bestAsteroid = candidate;
          bestDlosCount = dlosCount;
        }
      }

      return bestAsteroid;
    }

    public Asteroid Vaporize(Asteroid home, List<Asteroid> asteroids, int toVaporize) {
      int decimals = 6;
      foreach (Asteroid ast in asteroids) {
        ast.Radius = Math.Round(Distance(home.X,  home.Y, ast.X, ast.Y), decimals);

        ast.RadiansAngle = Angle(home.X, home.Y, ast.X, ast.Y); 
        ast.RadiansAngle = (ast.RadiansAngle + Math.PI / 2) % (2 * Math.PI);
        ast.RadiansAngle = Math.Round(ast.RadiansAngle, decimals);
      }

      List<List<Asteroid>> groups = asteroids
        .OrderBy(a => a.RadiansAngle)
        .ThenBy(a => a.Radius)
        .GroupBy(a => a.RadiansAngle)
        .Select(grp => grp.ToList())
        .ToList();

      List<Asteroid> grp;
      Asteroid vaporizedAsteroid = new Asteroid(-1, -1);
      int vaporizedAsteroids = 0;
      while(groups.Count > 0 && vaporizedAsteroids < toVaporize) {
        for(int i = 0; i < groups.Count && vaporizedAsteroids < toVaporize; i++) {
          grp = groups[i];
          vaporizedAsteroid = grp[0];
          grp.Remove(vaporizedAsteroid);

          vaporizedAsteroids++;
        }

        groups = groups.Where(grp => grp.Count != 0).ToList();
      }

      return vaporizedAsteroid;
    }

    private int CountDLOS(Asteroid home, List<Asteroid> asteroids) {
      int decimals = 6;
      foreach (Asteroid ast in asteroids) {
        ast.Radius = Math.Round(Distance(home.X,  home.Y, ast.X, ast.Y), decimals);

        if(ast.Radius > 0.000) {
          ast.RadiansAngle = Math.Round(Angle(home.X, home.Y, ast.X, ast.Y), decimals); 
        } else {
          ast.RadiansAngle = Math.Round(-10.000, decimals);
        }
      }

      return asteroids.Select(ast => ast.RadiansAngle).Distinct().ToList().Count - 1;
    }

    public double Distance(double x1, double y1, double x2, double y2) {
      return Math.Pow(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2), 0.5);
    }

    public double Angle(double x1, double y1, double x2, double y2) {
      return (Math.Atan2((y2 - y1), (x2 - x1)) + (2 * Math.PI)) % (2 * Math.PI);
    }
  }
}
