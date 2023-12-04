namespace TddBank.Tests
{
    public class BankAccountTests
    {
        [Fact]
        public void New_Account_should_have_zero_as_Balance()
        {
            var ba = new BankAccount();

            Assert.Equal(0, ba.Balance);
        }

        [Fact]
        public void Deposit_should_add_to_Balance()
        {
            var ba = new BankAccount();

            ba.Deposit(5m);
            ba.Deposit(2m);

            Assert.Equal(7, ba.Balance);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Deposit_a_negative_value_or_zero_throws_ArgumentEx(decimal value)
        {
            var ba = new BankAccount();

            Assert.Throws<ArgumentException>(() => ba.Deposit(value));
        }

        [Fact]
        public void Withdraw_should_substract_from_Balance()
        {
            var ba = new BankAccount();
            ba.Deposit(10m);

            ba.Withdraw(2m);

            Assert.Equal(8, ba.Balance);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Withdraw_a_negative_value_or_zero_throws_ArgumentEx(decimal value)
        {
            var ba = new BankAccount();

            Assert.Throws<ArgumentException>(() => ba.Withdraw(value));
        }

        [Fact]
        public void Withdraw_below_zero_throws_InvalidOperationEx()
        {
            var ba = new BankAccount();
            ba.Deposit(10m);

            Assert.Throws<InvalidOperationException>(() => ba.Withdraw(12m));
        }
    }
}