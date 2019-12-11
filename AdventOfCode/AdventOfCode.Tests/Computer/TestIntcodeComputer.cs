using NUnit.Framework;

using AdventOfCode.Computer;

namespace AdventOfCode.Tests {
  public class IntcodeComputerTests {

    [TestCase(0, 2, new long[] { 1, 0, 0, 0, 99 })]
    [TestCase(0, 8, new long[] { 101, 8, 3, 0, 99 })]
    [TestCase(0, 16, new long[] { 1001, 2, 8, 0, 99 })]
    [TestCase(0, 10, new long[] { 1101, 2, 8, 0, 99 })]
    public void TestCompileAddOperation(long index, long expected, long[] program) {
      IntcodeComputer ic = new IntcodeComputer(program, 1);
      ic.Run();
      Assert.That(program[index], Is.EqualTo(expected));
    }

    [TestCase(3, 6, new long[] { 2, 3, 0, 3, 99 })]
    [TestCase(5, 9801, new long[] { 2, 4, 4, 5, 99, 0 })]
    [TestCase(5, 20, new long[] { 102, 4, 3, 5, 99, 0 })]
    [TestCase(5, 20, new long[] { 1002, 3, 4, 5, 99, 0 })]
    [TestCase(5, 16, new long[] { 1102, 4, 4, 5, 99, 0 })]
    public void TestCompileMultiplyOperation(long index, long expected, long[] program) {
      IntcodeComputer ic = new IntcodeComputer(program, 1);
      ic.Run();
      Assert.That(program[index], Is.EqualTo(expected));
    }

    [Test]
    public void TestCompileInputOperation() {
      long[] program = new long[] { 3, 3, 99, 0 };
      IntcodeComputer ic = new IntcodeComputer(program, 1);
      ic.Run();
      Assert.That(program[3], Is.EqualTo(1));
    }

    [Test]
    public void TestCompileOutputOperation() {
      long[] program = new long[] { 4, 3, 99, 200 };
      IntcodeComputer ic = new IntcodeComputer(program, 1);
      ic.Run();
      Assert.That(ic.Output, Is.EqualTo(200));
    }

    [TestCase(1, new long[] { 5, 6, 7, 104, 1, 99, 1, 3 })]
    [TestCase(3, new long[] { 105, 4, 4, 104, 3, 99 })]
    [TestCase(3, new long[] { 1005, 6, 3, 104, 3, 99, 1 })]
    public void TestCompileJumpIfTrueOperation(long expected, long[] program) {
      IntcodeComputer ic = new IntcodeComputer(program, 1);
      ic.Run();
      Assert.That(ic.Output, Is.EqualTo(expected));
    }

    [TestCase(1, new long[] { 6, 6, 7, 104, 1, 99, 0, 3 })]
    [TestCase(3, new long[] { 106, 0, 4, 104, 3, 99 })]
    [TestCase(3, new long[] { 1006, 6, 3, 104, 3, 99, 0 })]
    public void TestCompileJumpIfFalseOperation(long expected, long[] program) {
      IntcodeComputer ic = new IntcodeComputer(program, 1);
      ic.Run();
      Assert.That(ic.Output, Is.EqualTo(expected));
    }

    [TestCase(1, new long[] { 7, 5, 6, 0, 99, 0, 3 })]
    [TestCase(0, new long[] { 7, 5, 6, 0, 99, 3, 0 })]
    public void TestCompileLessThanOperation(long expected, long[] program) {
      IntcodeComputer ic = new IntcodeComputer(program, 1);
      ic.Run();
      Assert.That(program[0], Is.EqualTo(expected));
    }

    [TestCase(1, new long[] { 8, 5, 6, 0, 99, 3, 3 })]
    [TestCase(0, new long[] { 8, 5, 6, 0, 99, 3, 0 })]
    public void TestCompileEqualsOperation(long expected, long[] program) {
      IntcodeComputer ic = new IntcodeComputer(program, 1);
      ic.Run();
      Assert.That(program[0], Is.EqualTo(expected));
    }

    [TestCase(009,  new long[] { 009, 5, 204, -5, 99, 5 })]
    [TestCase(109,  new long[] { 109, 5, 204, -5, 99 })]
    [TestCase(209,  new long[] { 209, 5, 204, -5, 99, 5 })]
    public void TestCompileRelativeBaseOffsetOperation(long expected, long[] program) {
      IntcodeComputer ic = new IntcodeComputer(program, 1);
      ic.Run();
      Assert.That(ic.Output, Is.EqualTo(expected));
    }

    [TestCase(8, 1, new long[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 })]
    [TestCase(7, 0, new long[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 })]
    [TestCase(7, 1, new long[] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 })]
    [TestCase(9, 0, new long[] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 })]
    [TestCase(8, 1, new long[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 })]
    [TestCase(9, 0, new long[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 })]
    [TestCase(7, 1, new long[] { 3, 3, 1107, -1, 8, 3, 4, 3, 99 })]
    [TestCase(9, 0, new long[] { 3, 3, 1107, -1, 8, 3, 4, 3, 99 })]
    [TestCase(0, 0, new long[] { 3, 12, 6, 12, 15, 1, 13, 14,
                                13, 4, 13, 99, -1, 0, 1, 9 })]
    [TestCase(2, 1, new long[] { 3, 12, 6, 12, 15, 1, 13, 14,
                                13, 4, 13, 99, -1, 0, 1, 9 })]
    [TestCase(0, 0, new long[] { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 })]
    [TestCase(1, 1, new long[] { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 })]
    [TestCase(7, 999, new long[] { 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20,
                                  1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 
                                  20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101,
                                  1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99 })]
    [TestCase(8, 1000, new long[] { 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20,
                                  1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 
                                  20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101,
                                  1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99 })]
    [TestCase(9, 1001, new long[] { 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20,
                                  1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 
                                  20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101,
                                  1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99 })]
    [TestCase(1, 1219070632396864, new long[] {1102,34915192,34915192,7,4,7,99,0})]
    [TestCase(1, 1125899906842624, new long[] {104,1125899906842624,99})]
    public void TestCompileOutput(long input, long expected, long[] program) {
      IntcodeComputer ic = new IntcodeComputer(program, input);
      ic.Run();
      Assert.That(ic.Output, Is.EqualTo(expected));
    }

    [Test]
    public void TestSelfCopy() {
      long[] p = new long[] { 109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99 };
      IntcodeComputer ic = new IntcodeComputer(p, 1);
      ic.Run();
      Assert.That(ic.Output, Is.EqualTo(99));
    }

    [Test]
      public void TestCompileChain() {
        long[] program = new long[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 };
        IntcodeComputer ic = new IntcodeComputer(program, 1);
        ic.Run();
        Assert.That(program[0], Is.EqualTo(30));
        Assert.That(program[4], Is.EqualTo(2));
      }

    public void TestFailingCompilation() {
      long[] program = new long[] { 4, 0, 4, 1, 99 };
      IntcodeComputer ic = new IntcodeComputer(program, 1);
      ic.Run();
      Assert.That(ic.Output, Is.EqualTo(4));
    }
  }
}
