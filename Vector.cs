using System;

namespace Lab1
{
    public class Vector
    {

        private double length;
        private double angleInDegrees;

        public Vector(double length, double angleInDegrees)
        {
            this.length = length;
            this.angleInDegrees = angleInDegrees;
        }

        public double CalculateX()
        {
            // Переводимо градуси в радіани для системних функцій Math
            double radians = angleInDegrees * (Math.PI / 180.0);
            return length * Math.Cos(radians);
        }

        public double CalculateY()
        {
            double radians = angleInDegrees * (Math.PI / 180.0);
            return length * Math.Sin(radians);
        }

        public string GetPolarData()
        {
            return $"Вектор: довжина = {length}, кут = {angleInDegrees}°";
        }
    }
}
