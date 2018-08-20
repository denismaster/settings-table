using AutoFixture;
using Moq;
using System;
using Xunit;

namespace SettingsTable.Tests
{
    public class DateExtensionsTests
    {
        #region ContainsDate tests
        
        [Theory, AutoMockData]
        public void ContainsDateShouldReturnFalseWhenNullIsProvided(IDateInterval interval)
        {
            var result = interval.ContainsDate(null);

            Assert.False(result);
        }

        [Theory, AutoMockData]
        public void ContainsDateShouldReturnTrueWhenIntervalIsInfinite(IDateInterval interval, DateTime date)
        {
            var result = interval.ContainsDate(date);

            Assert.True(result);
        }

        [Theory, AutoMockData]
        public void ContainsDateShouldReturnTrueWhenDateIsInInterval(
            Mock<IDateInterval>  interval, DateTime date)
        {
            interval.SetupGet(s => s.StartDate).Returns(date.AddMonths(-1));
            interval.SetupGet(s => s.EndDate).Returns(date.AddMonths(1));

            var result = interval.Object.ContainsDate(date);

            Assert.True(result);
        }

        [Theory, AutoMockData]
        public void ContainsDateShouldReturnFalseWhenDateIsNotInInterval(
            Mock<IDateInterval> interval, DateTime date)
        {
            interval.SetupGet(s => s.StartDate).Returns(date.AddMonths(1));
            interval.SetupGet(s => s.EndDate).Returns(date.AddMonths(2));

            var result = interval.Object.ContainsDate(date);

            Assert.False(result);
        }

        [Theory, AutoMockData]
        public void ContainsDateShouldReturnTrueWhenDateIsLessThenEndInUnclosedInterval(
            Mock<IDateInterval> interval, DateTime endDate)
        {
            interval.SetupGet(s => s.EndDate).Returns(endDate);

            var result = interval.Object.ContainsDate(endDate.AddDays(-1));

            Assert.True(result);
        }

        [Theory, AutoMockData]
        public void ContainsDateShouldReturnTrueWhenDateIsBiggerThenStartInUnclosedInterval(
            Mock<IDateInterval> interval, DateTime startDate)
        {
            interval.SetupGet(s => s.StartDate).Returns(startDate);

            var result = interval.Object.ContainsDate(startDate.AddDays(1));

            Assert.True(result);
        }

        #endregion
    }
}
