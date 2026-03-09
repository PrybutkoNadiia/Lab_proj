using System;

public class Segment
{
    public double x1, y1, x2, y2;

    // Конструктор за замовчуванням
    public Segment()
    {
        x1 = 0;
        y1 = 0;
        x2 = 0;
        y2 = 0;
    }

    // Конструктор з параметрами
    public Segment(double a, double b, double c, double d)
    {
        x1 = a;
        y1 = b;
        x2 = c;
        y2 = d;
    }

    // Конструктор копіювання
    public Segment(Segment s)
    {
        x1 = s.x1;
        y1 = s.y1;
        x2 = s.x2;
        y2 = s.y2;
    }

    // Метод обчислення довжини відрізка
    public double Length()
    {
        return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
    }

    // Перевантаження оператора множення
    public static Segment operator *(Segment s, double k)
    {
        return new Segment(s.x1 * k, s.y1 * k, s.x2 * k, s.y2 * k);
    }

    // Перевантаження оператора додавання
    public static Segment operator +(Segment a, Segment b)
    {
        return new Segment(
            a.x1 + b.x1,
            a.y1 + b.y1,
            a.x2 + b.x2,
            a.y2 + b.y2
        );
    }

    // Метод виведення інформації
    public void Print()
    {
        Console.WriteLine("Start: (" + x1 + ", " + y1 + ")");
        Console.WriteLine("End: (" + x2 + ", " + y2 + ")");
        Console.WriteLine("Length: " + Length());
    }
}
