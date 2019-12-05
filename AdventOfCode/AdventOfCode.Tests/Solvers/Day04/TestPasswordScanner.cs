using NUnit.Framework;

using AdventOfCode.Solvers.Day04;

namespace AdventOfCode.Tests {
  public class PasswordScannerTests {
    [Test]
    public void TestValidNumber() {
      PasswordScanner ps = new PasswordScanner();
      Assert.That(ps.IsPasswordValid(112345), Is.EqualTo(false));
    }
  }
}
