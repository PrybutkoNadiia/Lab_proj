using System;

namespace VectorLibrary
{
    public class Vector
    {
        // Закриті поля (інкапсуляція)
        private double r;      // довжина
        private double angle;  // кут у радіанах

        // Властивості тільки для читання
        public double R
        {
            get { return r; }
        }

        public double Angle
        {
            get { return angle; }
        }

        // 1. Конструктор без параметрів
        public Vector()
        {
            r = 0;
            angle = 0;
        }

        // 2. Конструктор з параметрами
        public Vector(double r, double angle)
        {
            this.r = r;
            this.angle = angle;
        }

        // 3. Конструктор копіювання
        public Vector(Vector other)
        {
            this.r = other.r;
            this.angle = other.angle;
        }

        // Метод обчислення X
        public double GetX()
        {
            return r * Math.Cos(angle);
        }

        // Метод обчислення Y
        public double GetY()
        {
            return r * Math.Sin(angle);
        }

        // Деструктор
        ~Vector()
        {
            // Виконується при знищенні об'єкта
        }
    }
}
