using System.Collections.Generic;
using CodeAssignmentService.Utility.Helpers.DeliveryDate;
using NUnit.Framework;

namespace CodeAssignmentTest.Utility.Helpers
{
    public class DeliveryDateDictionaryTest
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void DictionaryShouldReturnOnlyThoseDaysWhichRepeatsForEachProduct()
        {
            var givenData = new[]
            {
                new[] {3, 5, 7, 1},
                new[] {8, 9, 7, 6},
                new[] {1, 3, 7, 9}
            };

            var expectedResult = new[] {7};

            var result = new DeliveryDateDictionary(givenData).DaysToDelivery;

            Assert.AreEqual(expectedResult,result);
        }

        [Test]
        public void DictionaryShouldReturnEmptyListWhenThereIsNoDayWhichOccuresForEachProduct()
        {
            var givenData = new[]
            {
                new[] {3, 5, 7, 1},
                new[] {8, 9, 5, 6},
                new[] {1, 3, 7, 9}
            };

            var expectedResult = new List<int>();

            var result = new DeliveryDateDictionary(givenData).DaysToDelivery;

            Assert.AreEqual(expectedResult, result);
        }
    }
}