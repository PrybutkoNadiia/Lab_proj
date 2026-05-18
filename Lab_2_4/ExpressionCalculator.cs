
using System;

namespace ClassLibrary1
{
    public class ExpressionCalculator
    {
        private double a;
        private double b;
        private double c;
        private double d;

        public double A => a;
        public double B => b;
        public double C => c;
        public double D => d;

        public ExpressionCalculator(double a, double b, double c, double d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }

        public double Calculate()
        {
            if (d == 0)
            {
                throw new DivideByZeroException("Помилка: Ділення на нуль (значення параметра d дорівнює 0) у виразі c/d!");
            }

            double logArgument = (4 * b) - c;

            LogarithmEvaluator logEvaluator = new LogarithmEvaluator();

            double logResult = logEvaluator.CalculateLogarithm(logArgument);

            double denominator = b + (c / d) - 1;

            if (denominator == 0)
            {
                throw new DivideByZeroException("Помилка: Знаменник всього арифметичного виразу дорівнює нулю!");
            }

            return (logResult * a) / denominator;
        }
    }
}