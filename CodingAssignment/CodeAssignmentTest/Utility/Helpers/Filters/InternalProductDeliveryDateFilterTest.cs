using System;
using CodeAssignmentService.DeliveryDate.Utility.Helpers.Filters;
using CodeAssignmentService.Shared.Providers;
using CodeAssignmentService.Shared.Providers.Abstract;
using Moq;
using NUnit.Framework;

namespace CodeAssignmentTest.Utility.Helpers.Filters
{
    public class InternalProductDeliveryDateFilterTest
    {
        private InternalProductDeliveryDateFilter uut;
        private readonly DateTime currentDate = new DateTime(2020, 12, 07);
        [SetUp]
        public void Setup()
        {
            var timeProviderMock = new Mock<ITimeProvider>();
            timeProviderMock.Setup(m => m.GetToday()).Returns(currentDate);
            NextTwoWeeksDateProvider.GenerateTimeSpan(timeProviderMock.Object);
            uut = new InternalProductDeliveryDateFilter(timeProviderMock.Object);
        }

        [Test]
        public void FilterAvailableDeliveryDatesShouldReturnAllDatesDaysInAdvancePeriod()
        {

            var expectedResult = new[] { currentDate.AddDays(2), currentDate.AddDays(5), currentDate.AddDays(6), currentDate.AddDays(8), currentDate.AddDays(9), currentDate.AddDays(12), currentDate.AddDays(13) };
            var a = uut.FilterAvailableDeliveryDates(new[] { DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Saturday, DayOfWeek.Sunday }, 2);
            Assert.AreEqual(a, expectedResult);
        }
    }
}