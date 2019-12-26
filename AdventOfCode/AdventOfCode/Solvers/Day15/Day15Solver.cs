using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using AdventOfCode.Computer;

namespace AdventOfCode.Solvers {
  public class Day15Solver : Solver {
    public string SolvePartOne(string[] input) {
      long[] program = string.Join(",", input)
        .Split(",")
        .Select(x => Int64.Parse(x))
        .ToArray();

      RepairDroid droid = new RepairDroid(program);
      Dictionary<Point, long> tankMap = droid.MapOxygenTank();
      Dictionary<Point, int> distances = FillWithOxygen(tankMap);
     
      return distances[new Point(0, 0)].ToString();
    }

    public string SolvePartTwo(string[] input) {
      long[] program = string.Join(",", input)
        .Split(",")
        .Select(x => Int64.Parse(x))
        .ToArray();

      RepairDroid droid = new RepairDroid(program);
      Dictionary<Point, long> tankMap = droid.MapOxygenTank();
      Dictionary<Point, int> distances = FillWithOxygen(tankMap);

      return distances.Select(e => e.Value).ToArray().Max().ToString();
    }

    public Dictionary<Point, int> FillWithOxygen(Dictionary<Point, long> map) {
      List<Point> elementsToAdd = map
        .Where(e => e.Value == RepairDroid.FLOOR)
        .Select(e => e.Key).ToList();

      Point oxygenPoint = map
        .Where(e => e.Value == RepairDroid.DEST)
        .Select(e => e.Key)
        .First();
      
      Dictionary<Point, int> positions = new Dictionary<Point, int>();
      positions[oxygenPoint] = 0;

      while(elementsToAdd.Count != 0) {
        for(int i = 0; i < elementsToAdd.Count; ) {
          int lowestDistance = Int32.MaxValue;
          int distance = 0;

          Point p = new Point(elementsToAdd[i].X - 1, elementsToAdd[i].Y);
          if(positions.TryGetValue(p, out distance)) {
            lowestDistance = Math.Min(lowestDistance, distance + 1);
          }

          p = new Point(elementsToAdd[i].X + 1, elementsToAdd[i].Y);
          if(positions.TryGetValue(p, out distance)) {
            lowestDistance = Math.Min(lowestDistance, distance + 1);
          }

          p = new Point(elementsToAdd[i].X, elementsToAdd[i].Y - 1);
          if(positions.TryGetValue(p, out distance)) {
            lowestDistance = Math.Min(lowestDistance, distance + 1);
          }

          p = new Point(elementsToAdd[i].X, elementsToAdd[i].Y + 1);
          if(positions.TryGetValue(p, out distance)) {
            lowestDistance = Math.Min(lowestDistance, distance + 1);
          }

          if(lowestDistance != Int32.MaxValue) {
            positions[elementsToAdd[i]] = lowestDistance;
            elementsToAdd.RemoveAt(i);
          } else {
            i++;
          }
        }
      }

      return positions;
    }

    private void printTankMap(Dictionary<Point, long> map) {
      int minX = map.Select(e => e.Key.X).ToArray().Min();
      int maxX = map.Select(e => e.Key.X).ToArray().Max();
      int minY = map.Select(e => e.Key.Y).ToArray().Min();
      int maxY = map.Select(e => e.Key.Y).ToArray().Max();

      Dictionary<long, char> characters = new Dictionary<long, char>();
      characters.Add(0, '\u25FC');
      characters.Add(1, '\u25FB');
      characters.Add(2, 'O');
      characters.Add(3, 'X');

      map[new Point(0, 0)] = 3;

      long val = 0;
      for(int y = minY; y <= maxY; y++) {
        for(int x = minX; x <= maxX; x++) {
          map.TryGetValue(new Point(x, y), out val);
          Console.Write(characters[val]);
        } 

        Console.WriteLine();
      }
    }
  }
}
