namespace Calculator.Tests.CalcTests
{
    public class MultiplyTests
    {
        [Fact]
        public void Multiply_2_and_4_results_8()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Multiply(2, 4);

            //Assert
            Assert.Equal(8, result);
        }
    }
}