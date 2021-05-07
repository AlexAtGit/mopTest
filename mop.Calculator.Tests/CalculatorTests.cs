using System;
using Xunit;
using mop.BaseCalculator.Interfaces;

namespace mop.Calculator.Tests
{
    public class CalculatorTests
    {
        /// <summary>
        /// Tests adding two integer values
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 5)]
        [InlineData(-19, 36)]
        [InlineData(int.MaxValue, 0)]
        [InlineData(int.MaxValue, -int.MaxValue)]
        public void AddTwoIntNumbersOK(int a, int b)
        {
            ICalculator<int> addCalc = new Calculator.AddCalculator<int>();

            var expectedResult = a + b;
            var actualResult = addCalc.Calculate(a, b);
            Assert.Equal(expectedResult, actualResult);
        }

        /// <summary>
        /// Tests adding two single (float) values
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [Theory]
        [InlineData(0.0F, 0.0F)]
        [InlineData(0.0F, 5.0F)]
        [InlineData(-19.5F, 36.2F)]
        [InlineData(float.MaxValue, 0.0F)]
        [InlineData(float.MaxValue, -float.MaxValue)]
        public void AddTwoFloatNumbersOK(float a, float b)
        {
            ICalculator<float> addCalc = new Calculator.AddCalculator<float>();

            var expectedResult = a + b;
            var actualResult = addCalc.Calculate(a, b);
            Assert.Equal(expectedResult, actualResult);
        }

        /// <summary>
        /// If we use the checked calculator, test that we get an exception thrown where applicable
        /// </summary>
        [Fact]
        public void OverflowExceptionIntTest()
        {
            ICalculator<int> addCalc = new Calculator.AddCalculatorChecked<int>();

            var a = 2;
            var b = 6;
            var expectedResult = a + b;
            var actualResult = addCalc.Calculate(a, b);
            Assert.Equal(expectedResult, actualResult);

            Assert.Throws<OverflowException>(() => addCalc.Calculate(int.MaxValue, int.MaxValue));
        }
    }
}
