using System;
using System.Collections.Generic;

namespace AdventOfCode.Solvers {
    public class Day00Solver : Solver {
        public string SolvePartOne(string haystack) {
            string needle = "(";
            int upCount = haystack.Length - haystack.Replace(needle, "").Length;
            int downCount = haystack.Length - upCount;

            return (upCount - downCount).ToString();
        }

        public string SolvePartTwo(string input) {
            int floor = 0;
            int i = 0;

            Dictionary<char, int> dict = new Dictionary<char, int>();
            dict.Add('(', 1);
            dict.Add(')', -1);

            int v;
            while(floor != -1 && i < input.Length) {
                if(dict.TryGetValue(input[i], out v)) {
                    floor += v;
                }

                i++;
            }
            
            return i.ToString();
        }
    }
}
