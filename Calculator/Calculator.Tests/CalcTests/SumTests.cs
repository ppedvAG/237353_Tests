namespace Calculator.Tests.CalcTests
{
    public class SumTests
    {
        [Fact]
        public void Sum_3_and_4_results_7()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(3, 4);

            //Assert
            Assert.Equal(7, result);
        }

        [Fact]
        public void Sum_0_and_0_results_0()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(0, 0);

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        [Trait("Category", "Unittest")]
        [Trait("Exception", "OverflowsException")]
        public void Sum_MAX_and_1_throws_OverflowsException()
        {
            var calc = new Calc();

            Assert.Throws<OverflowException>(() => calc.Sum(int.MaxValue, 1));
        }
    }
}