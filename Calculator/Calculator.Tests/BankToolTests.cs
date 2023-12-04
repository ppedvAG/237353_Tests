using FluentAssertions;

namespace Calculator.Tests
{
    public class BankToolTests
    {
        [Theory]
        [InlineData("DE34100500000010050000")]
        [InlineData("AX2112345600000785")]
        [InlineData("AL47212110090000000235698741")]
        [InlineData("AD1200012030200359100100")]
        [InlineData("AT611904300234573201")]
        
        public void IsValidIban_with_valid_IBANs(string iban)
        {
            var result = BankTool.IsValidIban(iban);

            //Assert.True(result);
            result.Should().BeTrue();

            "Text".Should().NotContain("#").And.Contain("x");
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        //[InlineData(null)]
        [InlineData("DE1")] //zu kurz
        [InlineData("9912345")] //fängt nicht mit Buchstaben an
        [InlineData("BBAA345")] //zeichen 3 und 4 sind keine Zahlen
        public void IsValidIban_with_invalid_IBANs(string iban)
        {
            var result = BankTool.IsValidIban(iban);

            result.Should().BeFalse();
        }

    }
}
