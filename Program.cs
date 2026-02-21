using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Встановлення кодування для коректного відображення української мови
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("--- Лабораторна робота 1.1 (Варіант 8) ---");

            Vector myVector = new Vector(10.0, 45.0);

            Console.WriteLine(myVector.GetPolarData());

            double x = myVector.CalculateX();
            double y = myVector.CalculateY();

            Console.WriteLine($"Координати кінця вектора: X = {x:F2}, Y = {y:F2}");

            // Щоб консоль не закрилася одразу
            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}
