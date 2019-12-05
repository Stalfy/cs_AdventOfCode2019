using NUnit.Framework;

using AdventOfCode.Solvers.Day04;

namespace AdventOfCode.Tests {
  public class PasswordScannerTests {
    [Test]
    public void TestValidNumber() {
      PasswordScanner ps = new PasswordScanner();
      Assert.That(ps.IsValidPassword(112345), Is.EqualTo(true));
    }

    [Test]
    public void TestNonIncreasingOrder() {
      PasswordScanner ps = new PasswordScanner();
      Assert.That(ps.IsValidPassword(112343), Is.EqualTo(false));
    }

    [Test]
    public void TestNoDigitsPair() {
      PasswordScanner ps = new PasswordScanner();
      Assert.That(ps.IsValidPassword(123456), Is.EqualTo(false));
    }

    [Test]
    public void TestPartTwoValidNumber() {
      PasswordScanner ps = new PasswordScanner();
      Assert.That(ps.IsValidPassword2(112233), Is.EqualTo(true));
      Assert.That(ps.IsValidPassword2(111122), Is.EqualTo(true));
    }

    [Test]
    public void TestPartTwoInvalidNumber() {
      PasswordScanner ps = new PasswordScanner();
      Assert.That(ps.IsValidPassword2(123444), Is.EqualTo(false));
    }
  }
}
