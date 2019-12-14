using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solvers.Day10 {
  public class MonitoringStation {
    public MonitoringStation() {}

    public Asteroid FindBestAsteroid(List<Asteroid> asteroids, out int bestDlosCount) {
      Asteroid bestAsteroid = new Asteroid(-1, -1);
      bestDlosCount = 0;

      int maxAllowedViewBlocks = asteroids.Count;
      int dlosCount = 0;
      foreach (Asteroid candidate in asteroids) {
        dlosCount = CountDLOS(candidate, asteroids, maxAllowedViewBlocks);

        if (dlosCount > bestDlosCount) {
          bestDlosCount = dlosCount;
          maxAllowedViewBlocks = asteroids.Count - dlosCount;
          bestAsteroid = candidate;
        }
      }

      return bestAsteroid;
    }

    private int CountDLOS(Asteroid home, List<Asteroid> asteroids, int maxViewBlocks) {
      int count = asteroids.Count - 1;
      int viewBlocks = 0;
      int minX;
      int maxX;
      int minY;
      int maxY;

      foreach (Asteroid target in asteroids) {
        minX = Math.Min(home.X, target.X);
        maxX = Math.Max(home.X, target.X);
        minY = Math.Min(home.Y, target.Y);
        maxY = Math.Max(home.Y, target.Y);

        int viewBlockingAsteroids = asteroids
          .Where(a => a.X >= minX
              && a.X <= maxX
              && a.Y >= minY
              && a.Y <= maxY
              && Distance(home, a) != 0
              && Distance(target, a) != 0
              && BlocksView(home, a, target))
          .ToList()
          .Count;

        if(0 < viewBlockingAsteroids) {
          count--;
          viewBlocks++;
        }

        if(viewBlocks >= maxViewBlocks) {
          return 0;
        }
      }

      return count;
    }

    private bool BlocksView(Asteroid home, Asteroid center, Asteroid target) {
      double delta = Math.Abs(Distance(home, center) 
          + Distance(center, target) 
          - Distance(home, target));

      return delta < 0.0000001;
    }

    private double Distance(Asteroid a, Asteroid b) {
      return Math.Pow(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2), 0.5);
    }
  }
}
