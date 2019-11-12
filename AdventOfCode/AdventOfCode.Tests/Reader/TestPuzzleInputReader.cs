using System.IO;

using NUnit.Framework;

using AdventOfCode.Reader;

namespace AdventOfCode.Tests {
    public class PuzzleInputReaderTests {

        [Test]
        public void TestFileNotFound() {
            string fp = Path.Combine(TestContext.CurrentContext.TestDirectory,
                                     "artifacts", "Reader", "Inexistant.txt");

            PuzzleInputReader reader = new PuzzleInputReader();
            string[] lines;

            Assert.That(reader.Read(fp, out lines), Is.EqualTo(false));
            Assert.That(lines, Is.EqualTo(null));
        }
        
        [Test]
        public void TestSingleLine() {
            string fp = Path.Combine(TestContext.CurrentContext.TestDirectory,
                                     "artifacts", "Reader", "SingleLine.txt");

            PuzzleInputReader reader = new PuzzleInputReader();
            string[] lines;

            Assert.That(reader.Read(fp, out lines), Is.EqualTo(true));
            Assert.That(lines.Length, Is.EqualTo(1));
        }

        [Test]
        public void TestMultiLine() {
            string fp = Path.Combine(TestContext.CurrentContext.TestDirectory,
                                     "artifacts", "Reader", "MultiLine.txt");

            PuzzleInputReader reader = new PuzzleInputReader();
            string[] lines;

            Assert.That(reader.Read(fp, out lines), Is.EqualTo(true));
            Assert.That(lines.Length, Is.EqualTo(2));
        }

        [Test]
        public void TestNoNewline() {
            string fp = Path.Combine(TestContext.CurrentContext.TestDirectory,
                                     "artifacts", "Reader", "MultiLine.txt");

            PuzzleInputReader reader = new PuzzleInputReader();
            string[] lines;

            Assert.That(reader.Read(fp, out lines), Is.EqualTo(true));
            Assert.That(lines.Length, Is.EqualTo(2));
            Assert.That(lines[0].Length, Is.EqualTo(6));
            Assert.That(lines[1].Length, Is.EqualTo(6));
        }
    }
}
