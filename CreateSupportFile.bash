#!/bin/bash

if [ $# -ne 2 ]; then
  echo "Usage: Day ClassName"
  exit
fi

FILE_DIR=./AdventOfCode/AdventOfCode/Solvers/Day$1
TEST_DIR=./AdventOfCode/AdventOfCode.Tests/Solvers/Day$1

FILE_PATH=$FILE_DIR/$2.cs
TEST_PATH=$TEST_DIR/Test$2.cs

# Create solver file.
echo "using System;"                          >> $FILE_PATH
echo ""                                       >> $FILE_PATH
echo "namespace AdventOfCode.Solvers.Day$1 {" >> $FILE_PATH
echo "  public class $2 {"                    >> $FILE_PATH
echo ""                                       >> $FILE_PATH
echo "  }"                                    >> $FILE_PATH
echo "}"                                      >> $FILE_PATH

# Create test file.
echo "using NUnit.Framework;"            >> $TEST_PATH
echo ""                                  >> $TEST_PATH
echo "using AdventOfCode.Solvers.Day$1;" >> $TEST_PATH
echo ""                                  >> $TEST_PATH
echo "namespace AdventOfCode.Tests {"    >> $TEST_PATH
echo "  public class $2Tests {"          >> $TEST_PATH
echo ""                                  >> $TEST_PATH
echo "  }"                               >> $TEST_PATH
echo "}"                                 >> $TEST_PATH
