using NUnit.Framework;

using AdventOfCode.Solvers;

namespace AdventOfCode.Tests {
    public class Tests {

        [TestCase("0", "(())")]
        [TestCase("0", "()()")]
        [TestCase("3", "(((")]
        [TestCase("3", "(()(()(")]
        [TestCase("3", "))(((((")]
        [TestCase("-1", "())")]
        [TestCase("-1", "))(")]
        [TestCase("-3", ")))")]
        [TestCase("-3", ")())())")]
        public void TestPartOne(string expected, string input) {
            Solver s = new Day00Solver();
            string result = s.SolvePartOne(input);
            Assert.That(expected, Is.EqualTo(result));
        }
    }
}
