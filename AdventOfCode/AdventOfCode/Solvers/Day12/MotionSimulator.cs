using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solvers.Day12 {
  public class MotionSimulator {
    private int Spaceship(int a, int b) {
      if (a < b) {
        return -1;
      }

      if (a > b) {
        return 1;
      }

      return 0;
    }

    public bool IsOriginalPositions(List<Moon> current, List<Moon> initial) {
      for(int i = 0; i < current.Count; i++) {
        if(current[i].PosX != initial[i].PosX) {
          return false;
        }
        
        if(current[i].PosY != initial[i].PosY) {
          return false;
        }

        if(current[i].PosZ != initial[i].PosZ) {
          return false;
        }
      }

      return true;
    }

    public int SystemEnergy(List<Moon> moons) {
      return moons.Select(m => m.GetEnergy()).Sum();
    }

    public void Simulate(List<Moon> moons, int steps) {
      for(int step = 0; step < steps; step++) {
        Step(moons);
      }
    }

    public void Step(List<Moon> moons) {
      UpdateVelocity(moons);
      UpdatePosition(moons);
    }

    public void UpdateVelocity(List<Moon> moons) {
      foreach (Moon moonA in moons) {
        foreach (Moon moonB in moons) {
          moonA.VelX -= Spaceship(moonA.PosX, moonB.PosX);
          moonA.VelY -= Spaceship(moonA.PosY, moonB.PosY);
          moonA.VelZ -= Spaceship(moonA.PosZ, moonB.PosZ);
        }
      }
    }

    public void UpdatePosition(List<Moon> moons) {
      foreach (Moon moon in moons) {
        moon.PosX += moon.VelX;
        moon.PosY += moon.VelY;
        moon.PosZ += moon.VelZ;
      }
    }
  }
}
