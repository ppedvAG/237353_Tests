using Microsoft.QualityTools.Testing.Fakes;
using System.Diagnostics.Metrics;

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
        [InlineData(2023, 11, 24, 12, 0, true)]
        [InlineData(2023, 11, 30, 12, 0, true)]
        public void OpeningHours_IsOpen(int y, int M, int d, int h, int m, bool result)
        {
            var dt = new DateTime(y, M, d, h, m, 0);
            var oh = new OpeningHours();

            Assert.Equal(result, oh.IsOpen(dt));
        }

        [Fact]
        public void IsWeekend()
        {
            using (var context = ShimsContext.Create())
            {
                var oh = new OpeningHours();
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 12, 4);
                Assert.False(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 12, 5);
                Assert.False(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 12, 6);
                Assert.False(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 12, 7);
                Assert.False(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 12, 8);
                Assert.False(oh.IsWeekend());

                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 12, 9);
                Assert.True(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 12, 10);
                Assert.True(oh.IsWeekend());
            }
        }
    }
}
