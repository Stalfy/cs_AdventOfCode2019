using System;
using System.Collections.Generic;

namespace AdventOfCode.Computer {
  public class IntcodeComputer {
    public enum State { Idle, Running, Paused, Halted };

    private long RelativeBase;
    private Dictionary<long, Func<long, long>> Getters;
    private Dictionary<long, Action<long, long>> Setters;

    protected long Idx;
    protected long[] _Program;
    protected Dictionary<long, Action<long[]>> Operations;

    public State CurrentState { get; set; }
    public long Input { get; set; }
    public long Output { get; set; }

    public IntcodeComputer(long[] program) {
      Operations = new Dictionary<long, Action<long[]>>(); 
      Operations.Add(1, AddOperation);
      Operations.Add(2, MultiplyOperation);
      Operations.Add(3, InputOperation);
      Operations.Add(4, OutputOperation);
      Operations.Add(5, JumpIfTrueOperation);
      Operations.Add(6, JumpIfFalseOperation);
      Operations.Add(7, LessThanOperation);
      Operations.Add(8, EqualsOperation);
      Operations.Add(9, RelativeBaseOffsetOperation);
      Operations.Add(99, HaltOperation);

      Getters = new Dictionary<long, Func<long, long>>(); 
      Getters.Add(0, PositionModeGetter);
      Getters.Add(1, ImmediateModeGetter);
      Getters.Add(2, RelativeModeGetter);

      Setters = new Dictionary<long, Action<long, long>>(); 
      Setters.Add(0, PositionModeSetter);
      Setters.Add(1, ImmediateModeSetter);
      Setters.Add(2, RelativeModeSetter);

      _Program = program;
      CurrentState = State.Idle;

      Idx = 0;
      RelativeBase = 0;

      Output = 0;
      Input = 0;
    }

    public IntcodeComputer(long[] program, long input) : this(program) {
      Input = input;
    }

    public void Run() {
      long opcode = 0;
      long[] parameterModes = new long[3];

      CurrentState = State.Running;
      while (State.Running == CurrentState) {
        opcode = ParseOpcode(parameterModes);
        Operations[opcode](parameterModes);
      }
    }

    protected long Retrieve(long idx, long mode) {

      return Getters[mode](idx);
    }

    private long PositionModeGetter(long idx) {
      if (_Program[idx] + 1 > _Program.Length) {
        Array.Resize(ref _Program, (int) _Program[idx] + 1);
      }

      return _Program[_Program[idx]];
    }

    private long ImmediateModeGetter(long idx) {
      return _Program[idx];
    }

    private long RelativeModeGetter(long idx) {
      if (RelativeBase + _Program[idx] + 1 > _Program.Length) {
        Array.Resize(ref _Program, (int) (RelativeBase + _Program[idx] + 1));
      }

      return _Program[RelativeBase + _Program[idx]];
    }

    protected void Store(long idx, long v, long mode) {
      if (idx > _Program.Length) {
        Array.Resize(ref _Program, (int) idx);
      }

      Setters[mode](idx, v);
    }

    private void PositionModeSetter(long idx, long v) {
      if (_Program[idx] + 1> _Program.Length) {
        Array.Resize(ref _Program, (int) _Program[idx] + 1);
      }

      _Program[_Program[idx]] = v;
    }

    private void ImmediateModeSetter(long idx, long v) {
      _Program[idx] = v;
    }

    private void RelativeModeSetter(long idx, long v) {
      if (RelativeBase + _Program[idx] + 1> _Program.Length) {
        Array.Resize(ref _Program, (int) (RelativeBase + _Program[idx] + 1));
      }

      _Program[RelativeBase + _Program[idx]] = v;
    }

    private long ParseOpcode(long[] parameterModes) {
        parameterModes[0] = (_Program[Idx] / 100) % 10;
        parameterModes[1] = (_Program[Idx] / 1000) % 10;
        parameterModes[2] = (_Program[Idx] / 10000) % 10;
    
        return _Program[Idx] % 100;
    }

    private void AddOperation(long[] modes) {
      long a = Retrieve(Idx + 1, modes[0]);
      long b = Retrieve(Idx + 2, modes[1]);
      Store(Idx + 3, a + b, modes[2]);

      Idx += 4;
    }

    private void MultiplyOperation(long[] modes) {
      long a = Retrieve(Idx + 1, modes[0]);
      long b = Retrieve(Idx + 2, modes[1]);
      Store(Idx + 3,  a * b, modes[2]);

      Idx += 4;
    }

    protected void InputOperation(long[] modes) {
      Store(Idx + 1, Input, modes[0]);
      
      Idx += 2;
    }

    protected void OutputOperation(long[] modes) {
      Output = Retrieve(Idx + 1, modes[0]);
      
      Idx += 2;
    }

    private void JumpIfTrueOperation(long[] modes) {
      long v = Retrieve(Idx + 1, modes[0]);
      Idx = (0 != v) ? Retrieve(Idx + 2, modes[1]) : Idx + 3;
    }

    private void JumpIfFalseOperation(long[] modes) {
      long v = Retrieve(Idx + 1, modes[0]);
      Idx = (0 == v) ? Retrieve(Idx + 2, modes[1]) : Idx + 3;
    }

    private void LessThanOperation(long[] modes) {
      long a = Retrieve(Idx + 1, modes[0]);
      long b = Retrieve(Idx + 2, modes[1]);
      Store(Idx + 3, Convert.ToInt32(a < b), modes[2]);

      Idx += 4;
    }

    private void EqualsOperation(long[] modes) {
      long a = Retrieve(Idx + 1, modes[0]);
      long b = Retrieve(Idx + 2, modes[1]);
      Store(Idx + 3, Convert.ToInt32(a == b), modes[2]);

      Idx += 4;
    }

    private void RelativeBaseOffsetOperation(long[] modes) {
      RelativeBase += Retrieve(Idx + 1, modes[0]);
      
      Idx += 2;
    }

    private void HaltOperation(long[] modes) { 
      CurrentState = State.Halted;
    }
  }
}
