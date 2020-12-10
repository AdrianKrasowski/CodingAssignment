using System;
using CodeAssignmentService.Shared.Providers;
using NUnit.Framework;

namespace CodeAssignmentTest.Shared.Providers
{
    public class GreenDatesProviderTest
    {
        
        [SetUp]
        public void Setup()
        {

        }

        [TestCase("07/12/2020", false)]
        [TestCase("08/12/2020", false)]
        [TestCase("09/12/2020", true)]
        [TestCase("10/12/2020", false)]
        [TestCase("11/12/2020", false)]
        [TestCase("12/12/2020", false)]
        [TestCase("13/12/2020", false)]

        public void IsGreenMethodShouldReturnTrueOnlyForWednesdays(string givenDate, bool expectedResult)
        {
            var date = DateTime.Parse(givenDate);
            Assert.AreEqual(GreenDatesProvider.IsDateGreen(date), expectedResult);
        }
    }
}