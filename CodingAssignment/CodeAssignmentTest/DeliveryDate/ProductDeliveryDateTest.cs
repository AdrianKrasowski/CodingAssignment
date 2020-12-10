using System;
using System.Collections.Generic;
using CodeAssignmentService.DeliveryDate.Models;
using CodeAssignmentService.Models;
using CodeAssignmentService.Shared.Providers;
using CodeAssignmentService.Shared.Providers.Abstract;
using Moq;
using NUnit.Framework;

namespace CodeAssignmentTest.DeliveryDate
{
    public class ProductDeliveryDateTest
    {
        private readonly DateTime _currentTime = new DateTime(2020,12,7);
        private Mock<ITimeProvider> _timeMock;

        [SetUp]
        public void Setup()
        {
            _timeMock = new Mock<ITimeProvider>();
            _timeMock.Setup(m => m.GetToday()).Returns(_currentTime);
            NextTwoWeeksDateProvider.GenerateTimeSpan(_timeMock.Object);
        }

        [Test]
        public void ShouldCreateObjectWithProductDeliveryDatesWithCorrectDates()
        {
            var givenProduct = new ProductDTO()
            {
                DaysInAdvance = 3,
                DeliveryDays = new []{DayOfWeek.Friday,DayOfWeek.Sunday},
                Name= "Some product",
                ProductId = 12,
                ProductType = "internal"
            };

            var expectedList = new[] {4, 6, 11, 13};

            var actualDeliveryDateList 
                = new ProductDeliveryDates(givenProduct,_timeMock.Object).DaysUntilDelivery;

            Assert.AreEqual(expectedList,actualDeliveryDateList);
        }

        [Test]
        public void ShouldCreateObjectWithEmptyProductDeliveryDatesWhenNoDeliveryDaysGiven()
        {
            var givenProduct = new ProductDTO()
            {
                DaysInAdvance = 3,
                DeliveryDays = new List<DayOfWeek>(),
                Name = "Some product",
                ProductId = 12,
                ProductType = "internal"
            };

            var expectedList = new List<int>();

            var actualDeliveryDateList
                = new ProductDeliveryDates(givenProduct, _timeMock.Object).DaysUntilDelivery;

            Assert.AreEqual(expectedList, actualDeliveryDateList);
        }
    }
}