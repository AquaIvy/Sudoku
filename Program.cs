using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] initalValue = new int[9, 9] {
                { 0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0}
            };

            SudokuSolve.Init(initalValue);
            SudokuSolve.Solve();

            Console.ReadKey();
        }
    }
}
