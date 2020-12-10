using System;
using System.Collections.Generic;
using CodeAssignmentService.DeliveryDate.Models.DTO;
using CodeAssignmentService.DeliveryDate.Models.Services;
using CodeAssignmentService.Models;
using CodeAssignmentService.Product.Validator;
using CodeAssignmentService.Shared.Providers.Abstract;
using CodeAssignmentService.Utility.Helpers.DeliveryDate;
using Moq;
using NUnit.Framework;

namespace CodeAssignmentTest.DeliveryDate.Services
{
    public class DeliveryDateScheduleServiceTest
    {
        private DeliveryDateScheduleService _uut;
        private readonly DateTime _currentDate = new DateTime(2020,12,7);

        [SetUp]
        public void Setup()
        {
            var _timeMock = new Mock<ITimeProvider>();
            _timeMock.Setup(m => m.GetToday()).Returns(_currentDate);
            _timeMock.Setup(m => m.GetDaysUntilEndOfWeek()).Returns(6);
            var availableDeliveryDateBuilder = new AvailableDeliveryDateBuilder(_timeMock.Object);
            var productValidator = new ProductValidator(_timeMock.Object);
            _uut = new DeliveryDateScheduleService(availableDeliveryDateBuilder,_timeMock.Object, productValidator);
        }

        [Test]
        public void WhenGivenListOfProductWithExistingCommonDeliveryDateTheDateShouldBeReturned()
        {
            var givenProducts = new[]
            {
                new ProductDTO()
                {
                    DaysInAdvance = 3,
                    DeliveryDays = new[] {DayOfWeek.Friday, DayOfWeek.Sunday},
                    Name = "Some product",
                    ProductId = 12,
                    ProductType = "internal"
                },
                new ProductDTO()
                {
                    DaysInAdvance = 2,
                    DeliveryDays = new[] {DayOfWeek.Sunday, DayOfWeek.Saturday,DayOfWeek.Monday},
                    Name = "Some product",
                    ProductId = 12,
                    ProductType = "External"
                },
                new ProductDTO()
                {
                    DaysInAdvance = 2,
                    DeliveryDays = new[] {DayOfWeek.Sunday, DayOfWeek.Wednesday,DayOfWeek.Monday},
                    Name = "Some product",
                    ProductId = 12,
                    ProductType = "temporary"
                },
            };

            var givenPostalCode = 12222;

            var expectedResult = new[]
            {
                new AvailableDeliveryDate()
                {
                    DeliveryDate = new DateTime(2020, 12, 13),
                    IsGreenDelivery = false,
                    PostalCode = givenPostalCode
                }
            };

            var actualResult = _uut.CalculateAvailableDeliveryDatesForProducts(givenPostalCode, givenProducts);

            Assert.AreEqual(expectedResult,actualResult);
        }

        [Test]
        public void WhenGivenListOfProductWithoutCommonDeliveryDateTheEmptyListShouldBeReturned()
        {
            var givenProducts = new[]
            {
                new ProductDTO()
                {
                    DaysInAdvance = 3,
                    DeliveryDays = new[] {DayOfWeek.Friday, DayOfWeek.Sunday},
                    Name = "Some product",
                    ProductId = 12,
                    ProductType = "internal"
                },
                new ProductDTO()
                {
                    DaysInAdvance = 2,
                    DeliveryDays = new[] {DayOfWeek.Sunday, DayOfWeek.Saturday,DayOfWeek.Monday},
                    Name = "Some product",
                    ProductId = 12,
                    ProductType = "External"
                },
                new ProductDTO()
                {
                    DaysInAdvance = 2,
                    DeliveryDays = new[] {DayOfWeek.Thursday, DayOfWeek.Wednesday,DayOfWeek.Monday},
                    Name = "Some product",
                    ProductId = 12,
                    ProductType = "temporary"
                },
            };

            var givenPostalCode = 12222;

            var expectedResult = new List<AvailableDeliveryDate>();

            var actualResult = _uut.CalculateAvailableDeliveryDatesForProducts(givenPostalCode, givenProducts);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void WhenGivenTemporaryProductWhichCannotBeDeliveredInThisWeekEmptyListShouldBeReturned()
        {
            var givenProducts = new[]
            {
                new ProductDTO()
                {
                    DaysInAdvance = 3,
                    DeliveryDays = new[] {DayOfWeek.Friday, DayOfWeek.Sunday},
                    Name = "Some product",
                    ProductId = 12,
                    ProductType = "internal"
                },
                new ProductDTO()
                {
                    DaysInAdvance = 2,
                    DeliveryDays = new[] {DayOfWeek.Sunday, DayOfWeek.Saturday,DayOfWeek.Monday},
                    Name = "Some product",
                    ProductId = 12,
                    ProductType = "External"
                },
                new ProductDTO()
                {
                    DaysInAdvance = 8,
                    DeliveryDays = new[] {DayOfWeek.Thursday, DayOfWeek.Sunday,DayOfWeek.Monday},
                    Name = "Some product",
                    ProductId = 12,
                    ProductType = "temporary"
                },
            };

            var givenPostalCode = 12222;

            var expectedResult = new List<AvailableDeliveryDate>();

            var actualResult = _uut.CalculateAvailableDeliveryDatesForProducts(givenPostalCode, givenProducts);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}