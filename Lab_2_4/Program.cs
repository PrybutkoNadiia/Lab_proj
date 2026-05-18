using System;
using ClassLibrary1; 

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Лабораторна робота 2.4. Дослідження виняткових ситуацій ===");

            ExpressionCalculator[] testCases = new ExpressionCalculator[]
            {
                new ExpressionCalculator(10, 5, 4, 2),  // Тест 1: Усе правильно. Аргумент логарифма = 16, знаменник = 6
                new ExpressionCalculator(5, 1, 10, 2),  // Тест 2: Помилка логарифма. Аргумент = 4*1 - 10 = -6 (<= 0)
                new ExpressionCalculator(2, 4, 3, 0),   // Тест 3: Ділення на нуль. Параметр d = 0
                new ExpressionCalculator(4, 0.5, 2, 4)  // Тест 4: Помилка знаменника. Знаменник = 0.5 + 2/4 - 1 = 0
            };

            for (int i = 0; i < testCases.Length; i++)
            {
                Console.WriteLine($"\n--- Обробка об'єкта №{i + 1} ---");
                Console.WriteLine($"Вхідні дані: a={testCases[i].A}, b={testCases[i].B}, c={testCases[i].C}, d={testCases[i].D}");

                try
                {
                    double result = testCases[i].Calculate();

                    Console.WriteLine($"Успіх! Результат виразу = {result:F4}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"[ПЕРЕХОПЛЕНО ArgumentException]: {ex.Message}");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"[ПЕРЕХОПЛЕНО DivideByZeroException]: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[КРИТИЧНА ПОМИЛКА]: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("Завершено роботу з поточним об'єктом.");
                }
            }

            Console.WriteLine("\nТестування програми завершено. Натисніть Enter для виходу...");
            Console.ReadLine();
        }
    }
}