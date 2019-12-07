using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

using AdventOfCode.Solvers;
using AdventOfCode.Reader;

namespace AdventOfCode {
  class Program {
    const byte MAX_DAY = 6;

    static public int Main(string[] args) {
      if(1 != args.Length) {
        Console.WriteLine("Arguments (1): puzzleDay");
        return -1;
      }

      int day;
      if(false == Int32.TryParse(args[0], out day)) {
        Console.WriteLine("Could not parse puzzle day.");
        return -1;
      }

      if(day > MAX_DAY || day < 0) {
        Console.WriteLine("Please select a day between 0 and {0}.", MAX_DAY);
        return -1;
      }

      string fileName = string.Format("Day{0:D2}.txt", day);
      string filePath = Path.Combine("AdventOfCode", "Puzzles", fileName);

      PuzzleInputReader reader = new PuzzleInputReader();
      string[] input;
      if(false == reader.Read(filePath, out input)) {
        Console.WriteLine("Could not read file {0}.", filePath);
        return -1;
      }

      Solver s;
      if(false == CreateSolver(day, out s)) {
        Console.WriteLine("Could not instantiate a solver.");
        return -1;
      }

      Stopwatch stopwatch = new Stopwatch();
      TimeSpan ts;
      String answer;

      stopwatch.Start();
      answer = s.SolvePartOne(input);
      stopwatch.Stop();
      ts = stopwatch.Elapsed;

      Console.WriteLine("Part 1: {0}", answer);
      Console.WriteLine("Time 1: {0:00}.{1:D3} seconds.", ts.Seconds, ts.Milliseconds);

      stopwatch.Restart();
      answer = s.SolvePartTwo(input);
      stopwatch.Stop();
      ts = stopwatch.Elapsed;

      Console.WriteLine("Part 2: {0}", answer);
      Console.WriteLine("Time 2: {0:00}.{1:D3} seconds.", ts.Seconds, ts.Milliseconds);

      return 0;
    }

    static private bool CreateSolver(int day, out Solver s) {
      s = null;

      string typeName = string.Format("AdventOfCode.Solvers.Day{0:D2}Solver", day);
      Assembly assembly = Assembly.GetExecutingAssembly();

      try {
        Type type = assembly.GetType(typeName, true);
        s = (Solver) Activator.CreateInstance(type);
      } catch {
        return false;
      }

      return true;
    }
  }
}
