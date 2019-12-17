using System;
using System.Collections.Generic;
using System.Linq;

using System.Text.RegularExpressions;

using AdventOfCode.Solvers.Day12;

namespace AdventOfCode.Solvers {
  public class Day12Solver : Solver {

    public string SolvePartOne(string[] input) {
      return SolvePartOne(input, 1000);
    }

    public string SolvePartOne(string[] input, int steps) {
      MotionSimulator ms = new MotionSimulator();

      List<Moon> moons = ParseInput(input);
      ms.Simulate(moons, steps);

      return ms.SystemEnergy(moons).ToString();
    }

    public string SolvePartTwo(string[] input) {
      MotionSimulator ms = new MotionSimulator();

      List<Moon> moons = ParseInput(input);
      List<Moon> initialState = ParseInput(input);

      long timelapseX = 0;
      long timelapseY = 0;
      long timelapseZ = 0;
      long step = 0;
      do {
        ms.Step(moons);
        step++;

        if(IsInitialXState(moons, initialState) && timelapseX == 0) {
          timelapseX = step;
        }
      
        if(IsInitialYState(moons, initialState) && timelapseY == 0) {
          timelapseY = step;
        }
      
        if(IsInitialZState(moons, initialState) && timelapseZ == 0) {
          timelapseZ = step;
        }
      
      } while(timelapseX == 0 || timelapseY == 0 || timelapseZ == 0);

      long steps = LCM(timelapseX, LCM(timelapseY, timelapseZ));

      return steps.ToString();
    }

    public List<Moon> ParseInput(string[] input) {
      List<Moon> moons = new List<Moon>();
      string pattern = @"<x=(-{0,1}\d+), y=(-{0,1}\d+), z=(-{0,1}\d+)>";

      foreach (string str in input) {
        Match match = Regex.Match(str, pattern);
        if(match.Success) {
          int x = Int32.Parse(match.Groups[1].Value);
          int y = Int32.Parse(match.Groups[2].Value);
          int z = Int32.Parse(match.Groups[3].Value);
          Moon m = new Moon(x, y, z);
          moons.Add(m);
        }
      }

      return moons;
    }

    public bool IsInitialXState(List<Moon> moons, List<Moon> initial) {
      bool isInitial = true;

      for(int i = 0; i < moons.Count && isInitial; i++) {
        isInitial &= moons[i].PosX == initial[i].PosX;
        isInitial &= moons[i].VelX == 0;
      }

      return isInitial;
    }

    public bool IsInitialYState(List<Moon> moons, List<Moon> initial) {
      bool isInitial = true;

      for(int i = 0; i < moons.Count && isInitial; i++) {
        isInitial &= moons[i].PosY == initial[i].PosY;
        isInitial &= moons[i].VelY == 0;
      }

      return isInitial;
    }

    public bool IsInitialZState(List<Moon> moons, List<Moon> initial) {
      bool isInitial = true;

      for(int i = 0; i < moons.Count && isInitial; i++) {
        isInitial &= moons[i].PosZ == initial[i].PosZ;
        isInitial &= moons[i].VelZ == 0;
      }

      return isInitial;
    }

    public long LCM(long a, long b) {
      return Math.Abs(a * b) / GCD(a, b);
    }

    public long GCD(long a, long b)
    {
      if (a == 0)
        return b;
      if (b == 0)
        return a;

      if (a > b)
        return GCD(a % b, b);
      else
        return GCD(a, b % a);
    }
  }
}
