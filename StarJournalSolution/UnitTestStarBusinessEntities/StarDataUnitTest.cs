using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nl.NeoRenaissance.StarJournal.StarBusinessEntities;

namespace nl.NeoRenaissance.StarJournal.UnitTestStarBusinessEntities {
    [TestClass]
    public class StarDataUnitTest {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Creating_StarObject_Title_Null_To_Ctor_Exception() {
            // arrange, act
            var data = new StarData(
                title: null,
                situationData: new SituationData(DateTime.Now, "descript"));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Creating_StarObject_SituationData_Null_To_Ctor_Exception() {
            // arrange, act
            var data = new StarData(
                title: "test title",
                situationData: null);
        }
        [TestMethod]
        public void TestCreatingStarObject_StoreSituation() {
            // act
            var title = "dit is een title";
            var situationData = new SituationData(DateTime.Now, "description");
            // arrange
            var data = new StarData(
                title: title, 
                situationData: situationData);
            
            // assert
            Assert.IsNotNull(data);
            Assert.AreEqual(title, data.Title);
            Assert.AreSame(situationData, data.Situation);
        }
        [TestMethod]
        public void Test_Read_Situation() {
            // arrange, act
            var data = new StarData(title: "Dit is een title", situationData: new SituationData(DateTime.Now, "descript"));

            // assert
            Assert.IsNotNull(data.Situation);
        }

    }
}
