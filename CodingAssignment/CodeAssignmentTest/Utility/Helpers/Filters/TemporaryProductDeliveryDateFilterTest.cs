using System;
using System.Collections.Generic;
using CodeAssignmentService.DeliveryDate.Utility.Helpers.Filters;
using CodeAssignmentService.Shared.Providers;
using CodeAssignmentService.Shared.Providers.Abstract;
using Microsoft.VisualStudio.CodeCoverage;
using Moq;
using NUnit.Framework;

namespace CodeAssignmentTest.Utility.Helpers.Filters
{
    public class TemporaryProductDeliveryDAteFilterTest
    {
        private TemporaryProductDeliveryDateFilter uut;
        private readonly DateTime currentDate = new DateTime(2020, 12, 07);
        [SetUp]
        public void Setup()
        {
            var timeProviderMock = new Mock<ITimeProvider>();
            timeProviderMock.Setup(m => m.GetToday()).Returns(currentDate);
            NextTwoWeeksDateProvider.GenerateTimeSpan(timeProviderMock.Object);
            uut = new TemporaryProductDeliveryDateFilter(timeProviderMock.Object);
        }

        
        [TestCase(DayOfWeek.Monday, 6)]
        [TestCase(DayOfWeek.Sunday, 0)]
        public void GetDaysUntilEndOfTheWeekShouldReturnExpectedNumberOfDaysUntilEndOfTheWeek(DayOfWeek dayOfWeek, int expectedResult)
        {
            var result = uut.GetDaysUntilEndOfTheWeek(dayOfWeek);
            Assert.AreEqual(result, expectedResult);
        }

        [Test]
        public void FilterAvailableDeliveryDatesShouldReturnOnlyDatesWithinCurrentWeek()
        {

            var expectedResult = new[] {currentDate.AddDays(5), currentDate.AddDays(6)};
            var a = uut.FilterAvailableDeliveryDates(new[] { DayOfWeek.Monday, DayOfWeek.Saturday, DayOfWeek.Sunday }, 2);
            Assert.AreEqual(a, expectedResult);
        }
    }
}