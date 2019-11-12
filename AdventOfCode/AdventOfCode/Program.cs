using System;
using AdventOfCode.Solvers;

namespace AdventOfCode {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            Solver s = new Day00Solver();
            Console.WriteLine(s.SolvePartTwo("()())"));
        }
    }
}
