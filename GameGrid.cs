using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class GameGrid
    {
        private int[,] grid;
        public int Rows;
        public int Columns;
        public int this[int r, int c]
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }
        public GameGrid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            grid = new int[Rows, Columns];
        }
        public bool IsInside(int r, int c)
        {
            return (r >= 0 && r < Rows && c >= 0 && c < Columns);
        }
        public bool IsEmpty(int r, int c)
        {
            return (IsInside(r, c) && grid[r, c] > 0);
        }
        public bool IsRowEmpty(int r) {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] != 0) return false;
            }
            return true;
        }
        public bool IsRowFull(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] == 0) return false;
            }
            return true;
        }
        private void ClearRow(int r) {
            for (int c = 0; c < Columns; c++)
            {
                grid[r, c] = 0;
            }
        }
        private void MoveRowDown(int r, int numberOfRows)
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r + numberOfRows, c] = grid[r, c];
                grid[r, c] = 0;
            }
        }
        public int ClearFullRows()
        {
            int cleared = 0;
            for (int r = Rows - 1; r >= 0; r--)
            {
                if (IsRowFull(r))
                {
                    cleared++;
                    ClearRow(r);
                }
                else if (cleared > 0)
                {
                    MoveRowDown(r, cleared);
                }
            }
            return cleared;
        }
    }
}
