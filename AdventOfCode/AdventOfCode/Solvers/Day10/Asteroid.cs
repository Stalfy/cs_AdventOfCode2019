namespace AdventOfCode.Solvers.Day10 {
  public class Asteroid {
    public double X { get; set; }
    public double Y { get; set; }
    public double RadiansAngle { get; set; }
    public double Radius { get; set; }

    public Asteroid(int x, int y) {
      X = x;
      Y = y;
      RadiansAngle = 0;
      Radius = 0;
    }
  }
}
