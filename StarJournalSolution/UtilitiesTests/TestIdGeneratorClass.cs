using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities.IdGenerator;

namespace UtilitiesTests
{
    [TestClass]
    public class TestIdGeneratorClass
    {
        [TestMethod]
        public void TestGenerateUnique()
        {
            // ARRANGE
            IGenerateId generator = new IdGeneratorClass();

            // ACT
            Guid id1 = generator.Unique();
            Guid id2 = generator.Unique();

            // ASSERT
            bool isValid = Guid.TryParse(id1.ToString(), out _);
            Assert.IsTrue(isValid);
            Assert.AreNotEqual(id1, id2);
        }
    }
}
