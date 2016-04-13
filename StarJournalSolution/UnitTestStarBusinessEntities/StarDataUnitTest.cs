using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nl.NeoRenaissance.StarJournal.StarBusinessEntities;

namespace nl.NeoRenaissance.StarJournal.UnitTestStarBusinessEntities {
    [TestClass]
    public class StarDataUnitTest {
        [TestMethod]
        public void TestCreatingStarObject_NewWorks() {
            // arrange, act
            var data = new StarData();
            // assert
            Assert.IsNotNull(data);
        }
    }
}
