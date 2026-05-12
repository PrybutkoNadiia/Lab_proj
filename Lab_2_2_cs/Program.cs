using GeometryLibrary;

class Program
{
    // Метод для виведення результатів
    static void PrintResult(Shape figure)
    {
        // Виклик методів через базовий клас
        Console.WriteLine($"Name: {figure.GetType().Name}");
        Console.WriteLine($"Area: {figure.GetArea():F2}");
        Console.WriteLine($"Perimeter: {figure.GetPerimeter():F2}");
        Console.WriteLine("-------------------------");
    }

    static void Main()
    {
        // Створення об'єктів класів
        Shape myRect = new Rectangle(0, 0, 4, 5);
        Shape myCircle = new Circle(3);

        // Демонстрація роботи (поліморфізм)
        PrintResult(myRect);
        PrintResult(myCircle);
    }
}