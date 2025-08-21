namespace SudokuSolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] sudoku_data =
            {
                {0,0,0,     0,0,1,      2,6,9},
                {0,7,2,     0,0,0,      0,0,0},
                {6,9,1,     8,3,2,      0,0,7},

                {0,3,0,     0,4,7,      1,0,0},
                {0,4,7,     0,0,0,      6,3,0},
                {0,0,9,     3,1,0,      0,7,0},

                {2,0,0,     7,8,5,      9,4,6},
                {0,0,0,     0,0,0,      7,8,0},
                {7,8,5,     6,0,0,      0,0,0}
            };

            Solver solver = new Solver(sudoku_data);

            solver.SolveIt();
        }
    }
}
