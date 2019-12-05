#!/bin/bash

if [ $# -ne 1 ]; then
  echo "Missing argument: Day"
  exit
fi

SOLVER_DIR=./AdventOfCode/AdventOfCode/Solvers/Day$1
TEST_DIR=./AdventOfCode/AdventOfCode.Tests/Solvers/Day$1

SOLVER_PATH=$SOLVER_DIR/Day$1Solver.cs
TEST_PATH=$TEST_DIR/TestDay$1Solver.cs

mkdir -p $SOLVER_DIR
mkdir -p $TEST_DIR

# Create solver file.
echo "namespace AdventOfCode.Solvers {"                  >> $SOLVER_PATH
echo "  public class Day$1Solver : Solver {"             >> $SOLVER_PATH
echo ""                                                  >> $SOLVER_PATH
echo "    public string SolverPartOne(string[] input) {" >> $SOLVER_PATH
echo "      return \"\";"                                >> $SOLVER_PATH
echo "    }"                                             >> $SOLVER_PATH
echo ""                                                  >> $SOLVER_PATH
echo "    public string SolverPartTwo(string[] input) {" >> $SOLVER_PATH
echo "      return \"\";"                                >> $SOLVER_PATH
echo "    }"                                             >> $SOLVER_PATH
echo "  }"                                               >> $SOLVER_PATH
echo "}"                                                 >> $SOLVER_PATH

# Create test file.
echo "using NUnit.Framework;"                                         >> $TEST_PATH
echo ""                                                               >> $TEST_PATH
echo "using AdventOfCode.Solvers;"                                    >> $TEST_PATH
echo ""                                                               >> $TEST_PATH
echo "namespace AdventOfCode.Tests {"                                 >> $TEST_PATH
echo "  public class Day$1SolverTests {"                              >> $TEST_PATH
echo ""                                                               >> $TEST_PATH
echo "    public void TestPartOne(string expected, string[] input) {" >> $TEST_PATH
echo "      Solver s = new Day$1Solver();"                            >> $TEST_PATH
echo "      string result = s.SolvePartOne(input);"                   >> $TEST_PATH
echo "      Assert.That(result, Is.EqualTo(expected));"               >> $TEST_PATH
echo "    }"                                                          >> $TEST_PATH
echo ""                                                               >> $TEST_PATH
echo "    public void TestPartTwo(string expected, string[] input) {" >> $TEST_PATH
echo "      Solver s = new Day$1Solver();"                            >> $TEST_PATH
echo "      string result = s.SolvePartTwo(input);"                   >> $TEST_PATH
echo "      Assert.That(result, Is.EqualTo(expected));"               >> $TEST_PATH
echo "    }"                                                          >> $TEST_PATH
echo "  }"                                                            >> $TEST_PATH
echo "}"                                                              >> $TEST_PATH
