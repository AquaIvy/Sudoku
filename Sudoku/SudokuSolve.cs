using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    class SudokuSolve
    {
        static Cell[,] board = null;
        static int find_row = 0;
        static int find_column = 0;

        public static void Init(int[,] initalValue)
        {
            if (initalValue.Length != 9 * 9) { return; }

            board = new Cell[9, 9];
            for (int row = 0; row < initalValue.GetLength(0); row++)
            {
                for (int column = 0; column < initalValue.GetLength(1); column++)
                {
                    board[row, column] = new Cell()
                    {
                        Num = initalValue[row, column],
                        IsFixed = initalValue[row, column] != 0
                    };
                }
            }
        }

        public static void Solve()
        {
            if (board == null) { return; }

            Solve(0, 0);
        }

        public static void NextAns()
        {
            IsFindAns = false;
            Solve(find_row, find_column);
            if (!IsFindAns)
            {
                Console.WriteLine("\n已找到所有答案");
            }
        }

        static bool IsFindAns = false;
        static int cnt = 0;
        private static void Solve(int row, int column)
        {
            if (row == 9)
            {
                //IsFindAns = true;
                //find_row = row;
                //find_column = column;

                Print();

                Console.Write("press any key to find next ans:");
                Console.ReadKey();
                return;
            }

            //初始值，跳到下一个单元
            if (board[row, column].IsFixed)
            {
                NextCell(row, column);
                return;
            }

            for (int i = 0; i < 9; i++)
            {
                //if (IsFindAns) return;

                board[row, column].Num++;
                if (VerifyCell(row, column))
                {
                    NextCell(row, column);
                }
            }

            //if (!IsFindAns)
            board[row, column].Num = 0;
        }

        private static void NextCell(int row, int column)
        {
            if (column < 8)
            {
                Solve(row, column + 1);
            }
            else
            {
                Solve(row + 1, 0);
            }
        }

        private static bool VerifyCell(int row, int column)
        {
            int num = board[row, column].Num;

            int t, u;
            //每一行每一列是否重复
            for (t = 0; t < 9; t++)
            {
                if ((t != row && board[t, column].Num == num) || (t != column && board[row, t].Num == num))
                    return false;
            }

            //每个九宫格是否重复
            int start_row = row / 3 * 3;
            int start_column = column / 3 * 3;
            for (t = start_row; t < start_row + 3; t++)
            {
                for (u = start_column; u < start_column + 3; u++)
                {
                    if ((t != row || u != column) && board[t, u].Num == num)
                        return false;
                }
            }

            return true;
        }

        public static void Print()
        {
            if (board == null) { return; }

            string print = string.Empty;
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int column = 0; column < board.GetLength(1); column++)
                {
                    print += board[row, column].Num + ",";
                }
                print += "\n";
            }
            Console.Write("\n\n\n" + print);
        }
    }
}
