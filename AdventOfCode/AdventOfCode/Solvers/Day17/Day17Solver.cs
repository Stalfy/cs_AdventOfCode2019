using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using AdventOfCode.Computer;
using AdventOfCode.Solvers.Day17;

namespace AdventOfCode.Solvers {
  public class Day17Solver : Solver {

    public string SolvePartOne(string[] input) {
      long[] program = string.Join(",", input)
        .Split(",")
        .Select(x => Int64.Parse(x))
        .ToArray();

      VacuumRobot vr = new VacuumRobot(program, false, true);
      Dictionary<Point, long> cameraFeed = GetCameraFeed(vr);

      cameraFeed.OrderBy(x => x.Key.Y)
        .ThenBy(x => x.Key.X)
        .Select(x => Convert.ToChar(x.Value))
        .ToList()
        .ForEach(x => Console.Write(x));

      return GetAlignmentParametersSum(cameraFeed).ToString();
    }

    public string SolvePartTwo(string[] input) {
      long[] cameraFeedProgram = string.Join(",", input)
        .Split(",").Select(x => Int64.Parse(x)).ToArray();
      long[] wakeupProgram = string.Join(",", input)
        .Split(",").Select(x => Int64.Parse(x)).ToArray();

      VacuumRobot vr = new VacuumRobot(cameraFeedProgram, false, true);
      Dictionary<Point, long> scaffolding = GetCameraFeed(vr)
        .Where(x => x.Value != 46 && x.Value != 10)
        .ToDictionary(x => x.Key, x => x.Value);

      ScaffoldPathBuilder spb = new ScaffoldPathBuilder();

      StringBuilder sb = new StringBuilder(); 
      spb.GetScaffoldInstructions(scaffolding)
        .Select(x => Convert.ToChar(x))
        .ToList().ForEach(c => sb.Append(c));
      
      string mainMovRoutine = sb.ToString();
      string movFunctionA = ReduceInstructions(ref mainMovRoutine, "A", 18, "ABC");
      string movFunctionB = ReduceInstructions(ref mainMovRoutine, "B", 20, "ABC");
      string movFunctionC = ReduceInstructions(ref mainMovRoutine, "C", 6, "ABC");

      wakeupProgram[0] = 2;
      vr = new VacuumRobot(wakeupProgram, true, false);
      vr.Run();
      EnterInput(vr, mainMovRoutine);
      EnterInput(vr, movFunctionA);
      EnterInput(vr, movFunctionB);
      EnterInput(vr, movFunctionC);
      EnterInput(vr, "n");

      while(vr.CurrentState != IntcodeComputer.State.Halted) {
        vr.Run();
      }

      Console.WriteLine();

      return vr.Output.ToString();
    }

    public void EnterInput(VacuumRobot vr, string inputs) {
      Console.WriteLine(inputs);
      List<long> ascii = inputs.Select(x => Convert.ToInt64(x)).ToList();

      foreach(long input in ascii) {
        vr.Input = input;
        vr.Run();
      }

      vr.Input = 10;
      vr.Run();
    }

    public Dictionary<Point, long> GetCameraFeed(VacuumRobot vr) {
      int x = 0;
      int y = 0;

      Dictionary<Point, long> cameraFeed = new Dictionary<Point, long>();

      do {
        vr.Run();
        long output = vr.Output;

        cameraFeed.Add(new Point(x, y), vr.Output);

        if(vr.Output == 10) {
          x = 0;
          y++;
        } else {
          x++;
        }
      } while (vr.CurrentState != IntcodeComputer.State.Halted);

      return cameraFeed;
    }

    public long GetAlignmentParametersSum(Dictionary<Point, long> cameraFeed) {
      return cameraFeed.Where(x => x.Value != 46
          && cameraFeed.ContainsKey(new Point(x.Key.X, x.Key.Y - 1))
          && cameraFeed.ContainsKey(new Point(x.Key.X, x.Key.Y + 1))
          && cameraFeed.ContainsKey(new Point(x.Key.X - 1, x.Key.Y))
          && cameraFeed.ContainsKey(new Point(x.Key.X + 1, x.Key.Y))
          && cameraFeed[new Point(x.Key.X, x.Key.Y - 1)] != 46
          && cameraFeed[new Point(x.Key.X, x.Key.Y + 1)] != 46
          && cameraFeed[new Point(x.Key.X - 1, x.Key.Y)] != 46
          && cameraFeed[new Point(x.Key.X + 1, x.Key.Y)] != 46)
        .Select(x => x.Key.X * x.Key.Y)
        .Sum();
    }

    public string ReduceInstructions(ref string instructions, string replacementChar,
        int targetLength, string tokensToAvoid) {
      int beginIdx = -1;
      bool charIsComma = true;
      bool charIsIllegalToken = true;
      while (charIsComma || charIsIllegalToken) {
        beginIdx++;
        charIsComma = ',' == instructions[beginIdx];
        charIsIllegalToken = tokensToAvoid.Contains(instructions[beginIdx]);
      }

      int endIdx = beginIdx + targetLength;
      bool containsIllegalToken = true;
      bool lastCharIsComma = true;
      while (lastCharIsComma || containsIllegalToken) {
        endIdx--;
        string sub = instructions.Substring(beginIdx, endIdx);
        containsIllegalToken = -1 != sub.IndexOfAny(tokensToAvoid.ToCharArray());
        lastCharIsComma = ',' == sub[endIdx - 1];
      }

      string replacedSubstring = instructions.Substring(beginIdx, endIdx);
      instructions = instructions.Replace(replacedSubstring, replacementChar);

      return replacedSubstring;
    }
  }
}
