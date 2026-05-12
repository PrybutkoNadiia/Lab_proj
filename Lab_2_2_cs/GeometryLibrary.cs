namespace GeometryLibrary
{
    // Створення базового класу Фігури
    public abstract class Shape
    {
        // Віртуальні методи для обчислення площі та периметра
        public abstract double GetArea();
        public abstract double GetPerimeter();
    }

    // Створення класу Прямокутник
    public class Rectangle : Shape
    {
        // Поля класу (дані)
        private double x1, y1, x2, y2;

        // Конструктор класу Прямокутник
        public Rectangle(double x1, double y1, double x2, double y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        // Реалізація обчислення площі
        public override double GetArea() => Math.Abs(x2 - x1) * Math.Abs(y2 - y1);

        // Реалізація обчислення периметра
        public override double GetPerimeter() => 2 * (Math.Abs(x2 - x1) + Math.Abs(y2 - y1));
    }

    // Створення класу Коло
    public class Circle : Shape
    {
        // Поле класу (радіус)
        private double radius;

        // Конструктор класу Коло
        public Circle(double radius)
        {
            this.radius = radius;
        }

        // Реалізація обчислення площі
        public override double GetArea() => Math.PI * radius * radius;

        // Реалізація обчислення периметра
        public override double GetPerimeter() => 2 * Math.PI * radius;
    }
}
