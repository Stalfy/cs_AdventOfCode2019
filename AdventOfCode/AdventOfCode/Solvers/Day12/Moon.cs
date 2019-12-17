using System;

namespace AdventOfCode.Solvers.Day12 {
  public class Moon {
    public int PosX { get; set; }
    public int PosY { get; set; }
    public int PosZ { get; set; }
    public int VelX { get; set; }
    public int VelY { get; set; }
    public int VelZ { get; set; }

    public Moon(int x, int y, int z) {
      PosX = x;
      PosY = y;
      PosZ = z;

      VelX = 0;
      VelY = 0;
      VelZ = 0;
    }

    public int GetEnergy() {
      return (Math.Abs(PosX) + Math.Abs(PosY) + Math.Abs(PosZ))
        * (Math.Abs(VelX) + Math.Abs(VelY) + Math.Abs(VelZ));
    }
  }
}
