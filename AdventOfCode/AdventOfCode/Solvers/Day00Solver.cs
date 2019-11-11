using System;

namespace AdventOfCode.Solvers {
    public class Day00Solver : Solver {
        public string SolvePartOne(string haystack) {
            string needle = "(";
            int upCount = haystack.Length - haystack.Replace(needle, "").Length;
            int downCount = haystack.Length - upCount;

            return (upCount - downCount).ToString();
        }

        public string SolvePartTwo(string input) {
            return "Part Two";
        }
    }
}
