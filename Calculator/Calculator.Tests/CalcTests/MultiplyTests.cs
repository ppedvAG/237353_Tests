namespace Calculator.Tests.CalcTests
{
    public class MultiplyTests
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(2, 4, 8)]
        [InlineData(-3, -10, 30)]
        [InlineData(-4, 5, -20)]
        public void Multiply_with_correct_results(int a, int b, int exp)
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Multiply(a, b);

            //Assert
            Assert.Equal(exp, result);
        }

        [Theory]
        [InlineData(int.MinValue, 2)]
        [InlineData(int.MaxValue, 2)]
        [Trait("Category","Unittest")]
        [Trait("Exception","OverflowsException")]
        public void Multiply_should_throw_OverflowException(int a, int b)
        {
            var calc = new Calc();
            
            Assert.Throws<OverflowException>(() => calc.Multiply(a, b));
        }
    }
}