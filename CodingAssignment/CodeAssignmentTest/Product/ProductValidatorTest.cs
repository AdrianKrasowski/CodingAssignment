using System;
using CodeAssignmentService.DeliveryDate.Models.Services;
using CodeAssignmentService.Models;
using CodeAssignmentService.Product.Validator;
using CodeAssignmentService.Shared.Providers.Abstract;
using Moq;
using NUnit.Framework;

namespace CodeAssignmentTest.Product
{
    public class ProductValidatorTest
    {
        private ProductValidator _uut;
        private readonly DateTime _currentDate = new DateTime(2020, 12, 7);

        [SetUp]
        public void Setup()
        {
            var _timeMock = new Mock<ITimeProvider>();
            _timeMock.Setup(m => m.GetToday()).Returns(_currentDate);
            _timeMock.Setup(m => m.GetDaysUntilEndOfWeek()).Returns(6);
            _uut = new ProductValidator(_timeMock.Object);
        }

        [Test]
        public void ShouldReturnTrueIfProductsCanHaveCommonDeliveryDate()
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
            Assert.True(_uut.AreValid(givenProducts));
        }

        [Test]
        public void ShouldReturnFalseIfTemporaryProductsCannotBeDeliveredInCurrentWeek()
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
            Assert.False(_uut.AreValid(givenProducts));
        }

        [Test]
        public void ShouldReturnFalseIfThereIsNoCommonDeliveryDayForAllProducts()
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
            Assert.False(_uut.AreValid(givenProducts));
        }
    }
}