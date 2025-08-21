using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class Solver
    {
        public int[,] data;
        int picked_i;
        int picked_j;

        public Solver(int[,] data)
        {
            this.data = data;
        }

        // Table Print Method
        public void printAll()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(data[i, j] + " ");
                    if(j == 2 || j == 5)
                    {
                        Console.Write(" | ");
                    }
                    
                }
                Console.WriteLine();
                if (i == 2 || i == 5)
                {
                    Console.WriteLine("-------+--------+------");
                }
            }
        }

        // Array with possible results
        public bool[] PossibleResults(int row, int col)
        {
            // Possible Results (Array)
            bool[] used = new bool[9];  // index 0-8

            // Row
            for (int j = 0; j < 9; j++)
            {
                if (data[row,j] != 0)
                {
                    int number = data[row,j];
                    used[number-1] = true;
                }
            }

            // Column
            for (int i = 0; i < 9; i++)
            {
                if (data[i, col] != 0)
                {
                    int number = data[i, col];
                    used[number - 1] = true;
                }
            }

            // 3x3 Square
            int StartRow = (row / 3) * 3;
            int StartCol = (col / 3) * 3;

            for (int i = StartRow; i < StartRow + 3; i++)
            {
                for (int j = StartCol; j < StartCol + 3; j++)
                {
                    if (data[i,j] != 0)
                    {
                        int number = data[i,j];
                        used[number - 1] = true;
                    }
                }
            }

            // Result

            return used;
        }

        // Solve Method
        public void SolveIt()
        {
            bool stillSolving = true;
            bool[] possibleResults = new bool[9];
            int row;
            int col;

            do
            {

                stillSolving = false;

                // Get another small square to solve
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (data[i,j] == 0)
                        {
                            stillSolving = true;
                            row = i;
                            col = j;
                            possibleResults = PossibleResults(row, col);

                            // How many results?
                            int resultCounter = 0;  // counter of soultions
                            int possibleValue = -1; // number, which is free to use from array of possible results

                            for (int k = 0; k < 9; k++)
                            {
                                if (possibleResults[k] == false) // false = free to use
                                {
                                    resultCounter++;
                                    possibleValue = k + 1; // transform index number to real number
                                }
                            }

                            if (resultCounter == 1) // only one soultion
                            {
                                data[i, j] = possibleValue;
                                Console.Clear();
                                printAll(); // print solution table
                            }
                        }
                    }
                }
            }
            while (stillSolving);

            
        }
    }
}
