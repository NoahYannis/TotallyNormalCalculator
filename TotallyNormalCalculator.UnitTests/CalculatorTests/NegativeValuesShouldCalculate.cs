using Xunit;

namespace TotallyNormalCalculator.UnitTests.CalculatorTests
{
    public class NegativeValuesShouldCalculate
    {
        [Theory]
        [InlineData(-3, 4.75, 1.75)]
        [InlineData(-11, 14, 3)]
        public void Add_SimpleValuesShouldCalculate(double firstNumber, double secondNumber, double expected)
        {
            double actual = CalculatorModel.Add(firstNumber, secondNumber);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-8.5, 2.25, -10.75)]
        public void Subtract_SimpleValuesShouldCalculate(double firstNumber, double secondNumber, double expected)
        {
            double actual = CalculatorModel.Subtract(firstNumber, secondNumber);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-8, 2.5, -20)]
        public void Multiply_SimpleValuesShouldCalculate(double firstNumber, double secondNumber, double expected)
        {
            double actual = CalculatorModel.Mulitply(firstNumber, secondNumber);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-6, 1.5, -4)]
        [InlineData(-42.23, 0, 0)]

        public void Divide_SimpleValuesShouldCalculate(double firstNumber, double secondNumber, double expected)
        {
            double actual = CalculatorModel.Divide(firstNumber, secondNumber);
            Assert.Equal(expected, actual);
        }
    }
}
