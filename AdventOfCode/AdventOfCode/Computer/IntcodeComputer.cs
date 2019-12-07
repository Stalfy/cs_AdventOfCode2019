using System;
using System.Collections.Generic;

namespace AdventOfCode.Computer {
  public class IntcodeComputer {
    public enum State { Idle, Running, Paused, Halted };

    private Dictionary<int, Func<int, int>> getters;

    protected int Idx;
    protected int[] _Program;
    protected Dictionary<int, Action<int[]>> operations;

    public State CurrentState { get; set; }
    public int Input { get; set; }
    public int Output { get; set; }

    public IntcodeComputer(int[] program) {
      operations = new Dictionary<int, Action<int[]>>(); 
      operations.Add(1, AddOperation);
      operations.Add(2, MultiplyOperation);
      operations.Add(3, InputOperation);
      operations.Add(4, OutputOperation);
      operations.Add(5, JumpIfTrueOperation);
      operations.Add(6, JumpIfFalseOperation);
      operations.Add(7, LessThanOperation);
      operations.Add(8, EqualsOperation);
      operations.Add(99, HaltOperation);

      getters = new Dictionary<int, Func<int, int>>(); 
      getters.Add(0, PositionModeGetter);
      getters.Add(1, ImmediateModeGetter);

      _Program = program;
      CurrentState = State.Idle;
      Output = 0;
      Idx = 0;
      Input = 0;
    }

    public IntcodeComputer(int[] program, int input) : this(program) {
      Input = input;
    }

    public void Run() {
      int opcode = 0;
      int[] parameterModes = new int[2];

      CurrentState = State.Running;
      while (State.Running == CurrentState) {
        opcode = ParseOpcode(parameterModes);
        operations[opcode](parameterModes);
      }
    }

    private int ParseOpcode(int[] parameterModes) {
        parameterModes[0] = (_Program[Idx] / 100) % 10;
        parameterModes[1] = (_Program[Idx] / 1000) % 10;
    
        return _Program[Idx] % 100;
    }

    private void AddOperation(int[] modes) {
      int a = getters[modes[0]](Idx + 1);
      int b = getters[modes[1]](Idx + 2);
      _Program[_Program[Idx + 3]] =  a + b;

      Idx += 4;
    }

    private void MultiplyOperation(int[] modes) {
      int a = getters[modes[0]](Idx + 1);
      int b = getters[modes[1]](Idx + 2);
      _Program[_Program[Idx + 3]] =  a * b;

      Idx += 4;
    }

    protected void InputOperation(int[] modes) {
      _Program[_Program[Idx + 1]] = Input;
      
      Idx += 2;
    }

    private void OutputOperation(int[] modes) {
      Output = getters[modes[0]](Idx + 1);
      
      Idx += 2;
    }

    private void JumpIfTrueOperation(int[] modes) {
      int v = getters[modes[0]](Idx + 1);
      Idx = (0 != v) ? getters[modes[1]](Idx + 2) : Idx + 3;
    }

    private void JumpIfFalseOperation(int[] modes) {
      int v = getters[modes[0]](Idx + 1);
      Idx = (0 == v) ? getters[modes[1]](Idx + 2) : Idx + 3;
    }

    private void LessThanOperation(int[] modes) {
      int a = getters[modes[0]](Idx + 1);
      int b = getters[modes[1]](Idx + 2);
      _Program[_Program[Idx + 3]] = Convert.ToInt32(a < b);

      Idx += 4;
    }

    private void EqualsOperation(int[] modes) {
      int a = getters[modes[0]](Idx + 1);
      int b = getters[modes[1]](Idx + 2);
      _Program[_Program[Idx + 3]] = Convert.ToInt32(a == b);

      Idx += 4;
    }

    private void HaltOperation(int[] modes) { 
      CurrentState = State.Halted;
    }

    private int PositionModeGetter(int idx) {
      return _Program[_Program[idx]];
    }

    private int ImmediateModeGetter(int idx) {
      return _Program[idx];
    }
  }
}
