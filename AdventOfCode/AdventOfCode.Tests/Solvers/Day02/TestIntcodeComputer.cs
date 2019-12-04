using NUnit.Framework;

using AdventOfCode.Solvers.Day02;

namespace AdventOfCode.Tests {
  public class IntcodeComputerTests {

    [Test]
    public void TestCompileOpcode1() {
      IntcodeComputer ic = new IntcodeComputer();
      int[] program = new int[] { 1, 0, 0, 0, 99 };
      int[] compiledProgram = ic.Compile(program);
      Assert.That(compiledProgram[0], Is.EqualTo(2));
    }

    [TestCase(3, 6, new int[] { 2, 3, 0, 3, 99 })]
    [TestCase(5, 9801, new int[] { 2, 4, 4, 5, 99, 0 })]
    public void TestCompileOpcode2(int index, int expected, int[] program) {
      IntcodeComputer ic = new IntcodeComputer();
      int[] compiledProgram = ic.Compile(program);
      Assert.That(compiledProgram[index], Is.EqualTo(expected));
    }

    [Test]
    public void TestCompileChain() {
      IntcodeComputer ic = new IntcodeComputer();
      int[] program = new int[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 };
      int[] compiledProgram = ic.Compile(program);
      Assert.That(compiledProgram[0], Is.EqualTo(30));
      Assert.That(compiledProgram[4], Is.EqualTo(2));
    }
  }
}
