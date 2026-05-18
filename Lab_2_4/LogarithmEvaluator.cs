using System;

namespace ClassLibrary1 
{
    public class LogarithmEvaluator
    {
        public double CalculateLogarithm(double expression)
        {
            if (expression <= 0)
            {
                throw new ArgumentException("Помилка в методі логарифма: Аргумент повинен бути більшим за нуль!");
            }

            return Math.Log10(expression);
        }
    }
}
