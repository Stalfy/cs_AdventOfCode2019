using System.IO;

namespace AdventOfCode.Reader {
    public class PuzzleInputReader {
        public bool Read(string filePath, out string[] puzzle) {
            puzzle = null;

            try {
                puzzle = File.ReadAllLines(filePath);
            } catch {
                return false;
            }

            return true;
        }
    }
}
