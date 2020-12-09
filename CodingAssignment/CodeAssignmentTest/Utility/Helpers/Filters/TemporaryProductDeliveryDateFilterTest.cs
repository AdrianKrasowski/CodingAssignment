using System;
using System.Collections.Generic;
using CodeAssignmentService.DeliveryDate.Utility.Helpers.Filters;
using CodeAssignmentService.Shared.Providers;
using NUnit.Framework;

namespace CodeAssignmentTest.Utility.Helpers.Filters
{
    public class TemporaryProductDeliveryDAteFilterTest
    {
        private TemporaryProductDeliveryDateFilter uut;
        [SetUp]
        public void Setup()
        {
            NextTwoWeeksDateProvider.GenerateTimeSpan();
            uut = new TemporaryProductDeliveryDateFilter();
        }

        
        [TestCase(DayOfWeek.Monday, 6)]
        [TestCase(DayOfWeek.Sunday, 0)]
        public void TestGetDaysUntilEndOfTheWeek(DayOfWeek dayOfWeek, int expectedResult)
        {
            var result = uut.GetDaysUntilEndOfTheWeek(dayOfWeek);
            Assert.AreEqual(result, expectedResult);
        }

        [Test]
        public void Test()
        {
            var a = uut.FilterAvailableDeliveryDates(new[] { DayOfWeek.Monday, DayOfWeek.Saturday, DayOfWeek.Sunday }, 2);
            Assert.AreEqual(a, new[]{DateTime.Today.AddDays(3), DateTime.Today.AddDays(4) });
        }
    }
}