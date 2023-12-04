namespace TddBank.Tests
{
    public class OpeningHoursTests
    {
        [Theory]
        [InlineData(2023, 12, 4, 10, 30, true)]//mo
        [InlineData(2023, 12, 4, 10, 29, false)]//mo
        [InlineData(2023, 12, 4, 10, 31, true)] //mo
        [InlineData(2023, 12, 4, 18, 59, true)] //mo
        [InlineData(2023, 12, 4, 19, 00, false)] //mo
        [InlineData(2023, 12, 5, 12, 00, true)] //di
        [InlineData(2023, 12, 9, 10, 30, true)] //sa
        [InlineData(2023, 12, 9, 14, 0, false)] //sa
        [InlineData(2023, 12, 10, 12, 0, false)] //so
        [InlineData(2023, 12, 24, 12, 0, false)] 
        [InlineData(2023, 11, 24, 20, 0, false)] 
        [InlineData(2023, 11, 24, 12, 0, false)] 
        [InlineData(2023, 11, 30, 12, 0, true)] 
        public void OpeningHours_IsOpen(int y, int M, int d, int h, int m, bool result)
        {
            var dt = new DateTime(y, M, d, h, m, 0);
            var oh = new OpeningHours();

            Assert.Equal(result, oh.IsOpen(dt));
        }
    }
}
