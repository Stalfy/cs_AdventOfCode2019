using NUnit.Framework;

using AdventOfCode.Solvers;

namespace AdventOfCode.Tests {
  public class IntcodeComputerTests {

    [TestCase(0, 2, new int[] { 1, 0, 0, 0, 99 })]
    [TestCase(0, 8, new int[] { 101, 8, 3, 0, 99 })]
    [TestCase(0, 16, new int[] { 1001, 2, 8, 0, 99 })]
    [TestCase(0, 10, new int[] { 1101, 2, 8, 0, 99 })]
    public void TestCompileAddOperation(int index, int expected, int[] program) {
      IntcodeComputer ic = new IntcodeComputer(1);
      Assert.That(ic.Compile(program), Is.EqualTo(true));
      Assert.That(program[index], Is.EqualTo(expected));
    }

    [TestCase(3, 6, new int[] { 2, 3, 0, 3, 99 })]
    [TestCase(5, 9801, new int[] { 2, 4, 4, 5, 99, 0 })]
    [TestCase(5, 20, new int[] { 102, 4, 3, 5, 99, 0 })]
    [TestCase(5, 20, new int[] { 1002, 3, 4, 5, 99, 0 })]
    [TestCase(5, 16, new int[] { 1102, 4, 4, 5, 99, 0 })]
    public void TestCompileMultiplyOperation(int index, int expected, int[] program) {
      IntcodeComputer ic = new IntcodeComputer(1);
      Assert.That(ic.Compile(program), Is.EqualTo(true));
      Assert.That(program[index], Is.EqualTo(expected));
    }

    [Test]
    public void TestCompileInputOperation() {
      IntcodeComputer ic = new IntcodeComputer(1);
      int[] program = new int[] { 3, 3, 99, 0 };
      Assert.That(ic.Compile(program), Is.EqualTo(true));
      Assert.That(program[3], Is.EqualTo(1));
    }

    [Test]
    public void TestCompileOutputOperation() {
      IntcodeComputer ic = new IntcodeComputer(1);
      int[] program = new int[] { 4, 3, 99, 200 };
      Assert.That(ic.Compile(program), Is.EqualTo(true));
      Assert.That(ic.Output, Is.EqualTo(200));
    }

    [TestCase(1, new int[] { 5, 6, 7, 104, 1, 99, 1, 3 })]
    [TestCase(3, new int[] { 105, 4, 4, 104, 3, 99 })]
    [TestCase(3, new int[] { 1005, 6, 3, 104, 3, 99, 1 })]
    public void TestCompileJumpIfTrueOperation(int expected, int[] program) {
      IntcodeComputer ic = new IntcodeComputer(1);
      Assert.That(ic.Compile(program), Is.EqualTo(true));
      Assert.That(ic.Output, Is.EqualTo(expected));
    }

    [TestCase(1, new int[] { 6, 6, 7, 104, 1, 99, 0, 3 })]
    [TestCase(3, new int[] { 106, 0, 4, 104, 3, 99 })]
    [TestCase(3, new int[] { 1006, 6, 3, 104, 3, 99, 0 })]
    public void TestCompileJumpIfFalseOperation(int expected, int[] program) {
      IntcodeComputer ic = new IntcodeComputer(1);
      Assert.That(ic.Compile(program), Is.EqualTo(true));
      Assert.That(ic.Output, Is.EqualTo(expected));
    }

    [TestCase(1, new int[] { 7, 5, 6, 0, 99, 0, 3 })]
    [TestCase(0, new int[] { 7, 5, 6, 0, 99, 3, 0 })]
    public void TestCompileLessThanOperation(int expected, int[] program) {
      IntcodeComputer ic = new IntcodeComputer(1);
      Assert.That(ic.Compile(program), Is.EqualTo(true));
      Assert.That(program[0], Is.EqualTo(expected));
    }

    [TestCase(1, new int[] { 8, 5, 6, 0, 99, 3, 3 })]
    [TestCase(0, new int[] { 8, 5, 6, 0, 99, 3, 0 })]
    public void TestCompileEqualsOperation(int expected, int[] program) {
      IntcodeComputer ic = new IntcodeComputer(1);
      Assert.That(ic.Compile(program), Is.EqualTo(true));
      Assert.That(program[0], Is.EqualTo(expected));
    }

    [TestCase(8, 1, new int[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 })]
    [TestCase(7, 0, new int[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 })]
    [TestCase(7, 1, new int[] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 })]
    [TestCase(9, 0, new int[] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 })]
    [TestCase(8, 1, new int[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 })]
    [TestCase(9, 0, new int[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 })]
    [TestCase(7, 1, new int[] { 3, 3, 1107, -1, 8, 3, 4, 3, 99 })]
    [TestCase(9, 0, new int[] { 3, 3, 1107, -1, 8, 3, 4, 3, 99 })]
    [TestCase(0, 0, new int[] { 3, 12, 6, 12, 15, 1, 13, 14,
                                13, 4, 13, 99, -1, 0, 1, 9 })]
    [TestCase(2, 1, new int[] { 3, 12, 6, 12, 15, 1, 13, 14,
                                13, 4, 13, 99, -1, 0, 1, 9 })]
    [TestCase(0, 0, new int[] { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 })]
    [TestCase(1, 1, new int[] { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 })]
    [TestCase(7, 999, new int[] { 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20,
                                  1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 
                                  20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101,
                                  1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99 })]
    [TestCase(8, 1000, new int[] { 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20,
                                  1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 
                                  20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101,
                                  1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99 })]
    [TestCase(9, 1001, new int[] { 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20,
                                  1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 
                                  20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101,
                                  1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99 })]
    public void TestCompileOutput(int input, int expected, int[] program) {
      IntcodeComputer ic = new IntcodeComputer(input);
      Assert.That(ic.Compile(program), Is.EqualTo(true));
      Assert.That(ic.Output, Is.EqualTo(expected));
    }

    [Test]
    public void TestCompileChain() {
      IntcodeComputer ic = new IntcodeComputer(1);
      int[] program = new int[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 };
      Assert.That(ic.Compile(program), Is.EqualTo(true));
      Assert.That(program[0], Is.EqualTo(30));
      Assert.That(program[4], Is.EqualTo(2));
    }

    public void TestFailingCompilation() {
      IntcodeComputer ic = new IntcodeComputer(1);
      int[] program = new int[] { 4, 0, 4, 1, 99 };
      Assert.That(ic.Compile(program), Is.EqualTo(false));
      Assert.That(ic.Output, Is.EqualTo(4));
    }
  }
}
