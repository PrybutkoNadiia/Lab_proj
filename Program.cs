using System;

class Program
{
    static void Main()
    {
        // Створення об'єктів
        Segment L1 = new Segment();              // конструктор за замовчуванням
        Segment L2 = new Segment(1, 2, 3, 4);     // конструктор з параметрами
        Segment L3 = new Segment(L2);             // конструктор копіювання

        // Збільшити L3 у 2 рази
        L3 = L3 * 2;

        // Скласти L3 та L2
        L1 = L3 + L2;

        // Вивести результати
        Console.WriteLine("L1:");
        L1.Print();

        Console.WriteLine();

        Console.WriteLine("L2:");
        L2.Print();

        Console.WriteLine();

        Console.WriteLine("L3:");
        L3.Print();
    }
}