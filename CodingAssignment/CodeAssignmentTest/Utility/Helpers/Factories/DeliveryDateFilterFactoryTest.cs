using System;
using CodeAssignmentService.DeliveryDate.Utility.Factories;
using CodeAssignmentService.DeliveryDate.Utility.Helpers.Filters;
using CodeAssignmentService.Shared.Providers.Abstract;
using Moq;
using NUnit.Framework;

namespace CodeAssignmentTest.Utility.Helpers.Factories
{
    public class DeliveryDateFilterFactoryTest
    {
        private readonly DateTime _currentDate = new DateTime(2020,12,7);
        private Mock<ITimeProvider> _timeProvider;

        [SetUp]
        public void Setup()
        {
            _timeProvider = new Mock<ITimeProvider>();
            _timeProvider.Setup(m => m.GetToday()).Returns(_currentDate);
        }

        [TestCase("external", typeof(ExternalProductDeliveryDateFilter))]
        [TestCase("iNternal", typeof(InternalProductDeliveryDateFilter))]
        [TestCase("tempOrary", typeof(TemporaryProductDeliveryDateFilter))]
        [TestCase("Bla", typeof(InternalProductDeliveryDateFilter))]
        public void FactoryShouldReturnExpectedFilterForGivenStringDataNoMatterHowCasingLooksLike(
            string givenProductType, Type expectedTypeOfFilter)
        {
            var producedFilter = DeliveryDateFilterFactory.GenerateFilterForProductType(givenProductType, _timeProvider.Object);
            Assert.AreEqual(expectedTypeOfFilter,producedFilter.GetType());
        }
    }
}