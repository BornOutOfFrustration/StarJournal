using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities.DateTime;

namespace UtilitiesTests
{
    [TestClass]
    public class TestDateTimeClass
    {
        [TestMethod]
        public void TestCurrent()
        {
            // ARRANGE
            IDateTime dateTime = new DateTimeClass();

            // ACT
            DateTime now1 = DateTime.Now;
            DateTime actual = dateTime.Current;
            DateTime now2 = DateTime.Now;

            // ASSERT
            Assert.IsTrue(now1.CompareTo(actual) <= 0);
            Assert.IsTrue(now2.CompareTo(actual) >= 0);
        }
    }
}
