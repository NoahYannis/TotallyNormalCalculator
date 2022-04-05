using Xunit;

namespace TotallyNormalCalculator.UnitTests
{
    public class SimpleValuesShouldCalculate
    {
        [Theory]
        [InlineData(3,4,7)]
        [InlineData(13, 14, 27)]
        [InlineData(300, 400, 700)]
        public void Add_SimpleValuesShouldCalculate(double firstNumber, double secondNumber, double expected)
        {
            double actual = CalculatorModel.Add(firstNumber, secondNumber);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(8, 2, 6)]
        [InlineData(132, 12, 120)]
        [InlineData(3000, 400, 2600)]
        public void Subtract_SimpleValuesShouldCalculate(double firstNumber, double secondNumber, double expected)
        {
            double actual = CalculatorModel.Subtract(firstNumber, secondNumber);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(8, 2, 16)]
        [InlineData(11, 11, 121)]
        [InlineData(20, 13, 260)]
        public void Multiply_SimpleValuesShouldCalculate(double firstNumber, double secondNumber, double expected)
        {
            double actual = CalculatorModel.Mulitply(firstNumber, secondNumber);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(81, 9, 9)]
        [InlineData(11, 11, 1)]
        [InlineData(320, 10, 32)]
        [InlineData(42, 0, 0)]

        public void Divide_SimpleValuesShouldCalculate(double firstNumber, double secondNumber, double expected)
        {
            double actual = CalculatorModel.Divide(firstNumber, secondNumber);
            Assert.Equal(expected, actual);
        }


    }
}
