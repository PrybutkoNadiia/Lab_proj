using System;
using VectorLibrary;

class Program
{
    static void Main()
    {
        // Створенння об'єктів за допомогою оператора new та виклик конструкторів

        // Виклик конструктора без параметрів
        Vector v1 = new Vector();

        // Виклик конструктора з параметрами
        Vector v2 = new Vector(5, Math.PI / 4);

        // Виклик конструктора копіювання
        Vector v3 = new Vector(v2);

        Console.WriteLine("Вектор v2:");
        Console.WriteLine("r = " + v2.R);
        Console.WriteLine("кут = " + v2.Angle);
        Console.WriteLine("X = " + v2.GetX());
        Console.WriteLine("Y = " + v2.GetY());
    }
}