using NUnit.Framework;

using AdventOfCode.Solvers;

namespace AdventOfCode.Tests {
  public class IntcodeComputerTests {

    [TestCase(0, 2, new int[] { 1, 0, 0, 0, 99 })]
    [TestCase(0, 8, new int[] { 101, 8, 3, 0, 99 })]
    [TestCase(0, 16, new int[] { 1001, 2, 8, 0, 99 })]
    [TestCase(0, 10, new int[] { 1101, 2, 8, 0, 99 })]
    public void TestCompileAddOperation(int index, int expected, int[] program) {
      IntcodeComputer ic = new IntcodeComputer();
      Assert.That(ic.Compile(program), Is.EqualTo(true));
      Assert.That(program[index], Is.EqualTo(expected));
    }

    [TestCase(3, 6, new int[] { 2, 3, 0, 3, 99 })]
    [TestCase(5, 9801, new int[] { 2, 4, 4, 5, 99, 0 })]
    [TestCase(5, 20, new int[] { 102, 4, 3, 5, 99, 0 })]
    [TestCase(5, 20, new int[] { 1002, 3, 4, 5, 99, 0 })]
    [TestCase(5, 16, new int[] { 1102, 4, 4, 5, 99, 0 })]
    public void TestCompileOpcode2(int index, int expected, int[] program) {
      IntcodeComputer ic = new IntcodeComputer();
      Assert.That(ic.Compile(program), Is.EqualTo(true));
      Assert.That(program[index], Is.EqualTo(expected));
    }

    [Test]
    public void TestCompileChain() {
      IntcodeComputer ic = new IntcodeComputer();
      int[] program = new int[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 };
      Assert.That(ic.Compile(program), Is.EqualTo(true));
      Assert.That(program[0], Is.EqualTo(30));
      Assert.That(program[4], Is.EqualTo(2));
    }

    [Test]
    public void TestCompileInputOperation() {
      IntcodeComputer ic = new IntcodeComputer();
      int[] program = new int[] { 3, 3, 99, 0 };
      Assert.That(ic.Compile(program), Is.EqualTo(true));
      Assert.That(program[3], Is.EqualTo(1));
    }

    [Test]
    public void TestCompileOutputOperation() {
      IntcodeComputer ic = new IntcodeComputer();
      int[] program = new int[] { 4, 3, 99, 200 };
      Assert.That(ic.Compile(program), Is.EqualTo(true));
      Assert.That(ic.Output, Is.EqualTo(200));
    }
  }
}
