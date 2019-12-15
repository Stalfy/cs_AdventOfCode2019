using System;
using System.Collections.Generic;
using System.Linq;

using AdventOfCode.Solvers.Day10;

namespace AdventOfCode.Solvers {
  public class Day10Solver : Solver {

    public string SolvePartOne(string[] input) {
      List<Asteroid> asteroids = GetAsteroidCoordinates(input);
      MonitoringStation ms = new MonitoringStation();

      Asteroid a = ms.FindBestAsteroid(asteroids, out int observableAsteroids);
      return $"Best asteroid ({a.X},{a.Y}) can view {observableAsteroids} asteroids.";
    }

    public string SolvePartTwo(string[] input) {
      return SolvePartTwo(input, 200, 26, 29);
    }

    public string SolvePartTwo(string[] input, int toVaporize, int x, int y) {
      List<Asteroid> asteroids = GetAsteroidCoordinates(input);

      int index = asteroids.FindIndex(a => a.X == x && a.Y == y);
      Asteroid center = asteroids[index];
      asteroids.RemoveAt(index);

      MonitoringStation ms = new MonitoringStation();
      Asteroid lastVaporizedAsteroid = ms.Vaporize(center, asteroids, toVaporize);

      return (lastVaporizedAsteroid.X * 100 + lastVaporizedAsteroid.Y).ToString();
    }

    private List<Asteroid> GetAsteroidCoordinates(string[] input) {
      List<Asteroid> asteroids = new List<Asteroid>();

      for(int y = 0; y < input.Length; y++) {
        for(int x = 0; x < input[y].Length; x++) {
          if('#' == input[y][x]) {
            asteroids.Add(new Asteroid(x, y));
          }
        }
      }

      return asteroids;
    }
  }
}
