using System;
using System.Collections.Generic;
using CodeAssignmentService.DeliveryDate.Models.DTO;
using CodeAssignmentService.Shared.Providers.Abstract;
using CodeAssignmentService.Utility.Helpers.DeliveryDate;
using Moq;
using NUnit.Framework;

namespace CodeAssignmentTest.Utility.Helpers
{
    public class AvailableDeliveryDateBuilderTest
    {
        private AvailableDeliveryDateBuilder _uut;
        private readonly DateTime _currentDate = new DateTime(2020,12,7);

        [SetUp]
        public void Setup()
        {
            var timeProviderMock = new Mock<ITimeProvider>();
            timeProviderMock.Setup(m => m.GetToday()).Returns(_currentDate);
            _uut = new AvailableDeliveryDateBuilder(timeProviderMock.Object);
        }

        [Test]
        public void ForDayListAndPostalCodeBuilderShouldReturnProperAvailableDeliveryDates()
        {
            var givenDayList = new[] {1, 2, 3};
            var givenPostalCode = 12222;
            var expectedResult = new[]
            {
                new AvailableDeliveryDate()
                {
                    DeliveryDate = new DateTime(2020, 12, 8),
                    IsGreenDelivery = false,
                    PostalCode = givenPostalCode
                },
                new AvailableDeliveryDate()
                {
                    DeliveryDate = new DateTime(2020, 12, 9),
                    IsGreenDelivery = true,
                    PostalCode = givenPostalCode
                },
                new AvailableDeliveryDate()
                {
                    DeliveryDate = new DateTime(2020, 12, 10),
                    IsGreenDelivery = false,
                    PostalCode = givenPostalCode
                }
            };

            var result = _uut.GenerateAvailableDeliveryDates(givenPostalCode,givenDayList);
            Assert.AreEqual(expectedResult,result);
        }

        [Test]
        public void ForEmptyListAndPostalCodeBuilderShouldReturnEmptyList()
        {
            var givenDayList = new List<int>();
            var givenPostalCode = 12222;
            var expectedResult = new List<AvailableDeliveryDate>();

            var result = _uut.GenerateAvailableDeliveryDates(givenPostalCode, givenDayList);
            Assert.AreEqual(expectedResult, result);
        }
    }
}