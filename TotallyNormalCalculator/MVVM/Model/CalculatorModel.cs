using System;

namespace TotallyNormalCalculator
{
    public class CalculatorModel
    {
        public static double Add(double x, double y)
        {
            return x + y;
        }

        public static double Subtract(double x, double y)
        {
            return x - y;
        }

        public static double Mulitply(double x, double y)
        {
            return x * y;
        }

        public static double Divide(double x, double y)
        {
            if (y is 0)
            {
                return 0;
            }
            else
            {
                return x / y;
            }
        }
    }
}
