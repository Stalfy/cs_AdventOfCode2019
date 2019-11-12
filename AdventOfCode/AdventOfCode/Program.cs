using System;
using System.IO;

using AdventOfCode.Solvers;
using AdventOfCode.Reader;

namespace AdventOfCode {
    class Program {
        const byte MAX_DAY = 1;

        static public int Main(string[] args) {
            Console.WriteLine("Hello World!");
            if(1 != args.Length) {
                Console.WriteLine("Arguments (1): puzzleDay");
                return -1;
            }

            int n;
            if(false == Int32.TryParse(args[0], out n)) {
                Console.WriteLine("Could not parse puzzle day.");
                return -1;
            }

            if(n > MAX_DAY || n < 0) {
                Console.WriteLine("Please select a day between 0 and {0}.", MAX_DAY);
                return -1;
            }

            string fileName = string.Format("day{0:D2}.txt", n);
            string filePath = Path.Combine("AdventOfCode", "puzzles", fileName);
            Console.WriteLine(filePath);

            PuzzleInputReader reader = new PuzzleInputReader();
            string[] input;
            if(false == reader.Read(filePath, out input)) {
                Console.WriteLine("Could not read file {0}.", filePath);
                return -1;
            } 

            return 0;
        }
    }
}
