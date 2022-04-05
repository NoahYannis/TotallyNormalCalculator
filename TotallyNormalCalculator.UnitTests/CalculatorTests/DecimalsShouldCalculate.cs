using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TotallyNormalCalculator.UnitTests.CalculatorTests
{
    public class DecimalsShouldCalculate
    {
        [Theory]
        [InlineData(3.25, 4.75, 8)]
        [InlineData(13.11, 14.11, 27.22)]
        [InlineData(double.MaxValue, 14.11, double.MaxValue)]

        public void Add_SimpleValuesShouldCalculate(double firstNumber, double secondNumber, double expected)
        {
            double actual = CalculatorModel.Add(firstNumber, secondNumber);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(8.5, 2.25, 6.25)]
        public void Subtract_SimpleValuesShouldCalculate(double firstNumber, double secondNumber, double expected)
        {
            double actual = CalculatorModel.Subtract(firstNumber, secondNumber);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(8, 2.5, 20)]
        public void Multiply_SimpleValuesShouldCalculate(double firstNumber, double secondNumber, double expected)
        {
            double actual = CalculatorModel.Mulitply(firstNumber, secondNumber);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(6, 1.5, 4)]
        [InlineData(42.23, 0, 0)]

        public void Divide_SimpleValuesShouldCalculate(double firstNumber, double secondNumber, double expected)
        {
            double actual = CalculatorModel.Divide(firstNumber, secondNumber);
            Assert.Equal(expected, actual);
        }

    }
}
