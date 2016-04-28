using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nl.NeoRenaissance.StarJournal.StarBusinessEntities;

namespace UnitTestStarBusinessEntities {
    [TestClass]
    public class SituationDataUnitTest {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Initialization_Situation_Must_Get_A_Valid_DateTime() {
            // A Valid DateTime is a datetime that is set. DateTime.Kind cannot be unspecified.
            // arrange
            DateTime dateTime = new DateTime();
            //act
            var situationObject = new SituationData(dateTime, "");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Initialization_Situation_Must_Get_A_Valid_Description() {
            // A valid Description is an string that is not null. It can be empty, but never null.
            // arrange
            DateTime dateTime = DateTime.Now;
            var situationObject = new SituationData(dateTime, null);
        }

        [TestMethod]
        public void Test_StoreSituationDescriptionInCTor() {
            // arrange, // act
            DateTime dateTime = DateTime.Now;
            var dataToStore = "This is a text;" + Environment.NewLine + "Multiple lines of text.";
            var situationObject = new SituationData(dateTime, dataToStore);
                             
            // assert
            Assert.AreEqual(dataToStore, situationObject.Description);
        }
        [TestMethod]
        public void Test_StoreSituationDescription() {
            // arrange, // act
            DateTime dateTime = DateTime.Now;
            var dataToStore = "This is a text;" + Environment.NewLine + "Multiple lines of text.";
            var situationObject = new SituationData(dateTime, dataToStore);
            situationObject.Description = "abc";
            // assert
            Assert.AreEqual("abc", situationObject.Description);
        }
    }
}
