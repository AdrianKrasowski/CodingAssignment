using System;
using CodeAssignmentService.DeliveryDate.Utility.Helpers.Filters;
using CodeAssignmentService.Shared.Providers;
using CodeAssignmentService.Shared.Providers.Abstract;
using Moq;
using NUnit.Framework;

namespace CodeAssignmentTest.Shared.Providers
{
    public class NextTwoWeeksDatesProviderTest
    {
        private readonly DateTime _currentDate = new DateTime(2020, 12, 07);
        Mock<ITimeProvider> timeProviderMock = new Mock<ITimeProvider>();

        [SetUp]
        public void Setup()
        {
            timeProviderMock.Setup(m => m.GetToday()).Returns(_currentDate);
        }

        [Test]
        public void NextTwoWeeksDateProviderShouldReturnOnlyDatesInNextTwoWeeks()
        {
            var expectedResult = new[] {_currentDate, _currentDate.AddDays(1), _currentDate.AddDays(2) , _currentDate.AddDays(3) , _currentDate.AddDays(4) , _currentDate.AddDays(5) , _currentDate.AddDays(6) , _currentDate.AddDays(7) , _currentDate.AddDays(8) , _currentDate.AddDays(9) , _currentDate.AddDays(10) , _currentDate.AddDays(11) , _currentDate.AddDays(12) , _currentDate.AddDays(13) };

            NextTwoWeeksDateProvider.GenerateTimeSpan(timeProviderMock.Object);
            Assert.AreEqual(NextTwoWeeksDateProvider.DatesInNextTwoWeeks, expectedResult);
        }
    }
}