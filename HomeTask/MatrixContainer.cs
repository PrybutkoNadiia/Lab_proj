using System;

namespace ConsoleApp1
{
    public class MatrixContainer
    {
        private int[,] _matrix;

        public MatrixContainer(int rows, int cols)
        {
            if (rows <= 0 || cols <= 0)
            {
                throw new ArgumentException("Розміри масиву повинні бути більшими за нуль.");
            }
            _matrix = new int[rows, cols];
        }

        public int Rows
        {
            get { return _matrix.GetLength(0); }
        }

        public int Columns
        {
            get { return _matrix.GetLength(1); }
        }

        public int this[int row, int col]
        {
            get
            {
                if (row >= 0 && row < Rows && col >= 0 && col < Columns)
                {
                    return _matrix[row, col];
                }
                else
                {
                    Console.WriteLine($"[Помилка індексатора]: Індекси [{row}, {col}] виходять за межі масиву (Розмір: {Rows}x{Columns}).");
                    return 0;
                }
            }
            set
            {
                if (row >= 0 && row < Rows && col >= 0 && col < Columns)
                {
                    _matrix[row, col] = value;
                }
                else
                {
                    Console.WriteLine($"[Помилка індексатора]: Спроба запису за межі масиву за індексами [{row}, {col}].");
                }
            }
        }
    }
}
