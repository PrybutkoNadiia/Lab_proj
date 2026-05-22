using ConsoleApp1;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            MatrixContainer container = new MatrixContainer(3, 4);

            Console.WriteLine($"Створено матрицю розміром: {container.Rows}x{container.Columns}");

            int elementValue = 10;
            for (int i = 0; i < container.Rows; i++)
            {
                for (int j = 0; j < container.Columns; j++)
                {
                    container[i, j] = elementValue;
                    elementValue += 5;
                }
            }

            Console.WriteLine("\nВміст матриці:");
            for (int i = 0; i < container.Rows; i++)
            {
                for (int j = 0; j < container.Columns; j++)
                {
                    Console.Write($"{container[i, j]}\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n--- Тестування захисту індексатора від виходу за межі ---");

            Console.WriteLine("Спроба зчитати container[5, 2]:");
            int invalidRead1 = container[5, 2];

            Console.WriteLine("\nСпроба зчитати container[1, -1]:");
            int invalidRead2 = container[1, -1];

            Console.WriteLine("\nСпроба записати значення 99 в container[2, 10]:");
            container[2, 10] = 99;

            Console.WriteLine("\nПрограма завершила роботу. Натисніть будь-яку клавішу...");
            Console.ReadKey();
        }
    }
}