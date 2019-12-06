using NUnit.Framework;

using AdventOfCode.Solvers;

namespace AdventOfCode.Tests {
  public class IntcodeComputerTests {

    [Test]
    public void TestCompileOpcode1() {
      IntcodeComputer ic = new IntcodeComputer();
      int[] program = new int[] { 1, 0, 0, 0, 99 };
      Assert.That(ic.Compile(program), Is.EqualTo(true));
      Assert.That(program[0], Is.EqualTo(2));
    }

    [TestCase(3, 6, new int[] { 2, 3, 0, 3, 99 })]
    [TestCase(5, 9801, new int[] { 2, 4, 4, 5, 99, 0 })]
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
  }
}
