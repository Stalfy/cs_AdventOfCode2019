using NUnit.Framework;

using AdventOfCode.Solvers;

namespace AdventOfCode.Tests {
    public class Tests {
        [Test]
        public void TestIsTrue() {
            Solver s = new Day00Solver();
            Assert.IsTrue(s.IsTrue());
        }
    }
}
