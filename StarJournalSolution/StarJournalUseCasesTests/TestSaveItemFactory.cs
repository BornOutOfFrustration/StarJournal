//namespace StarJournalUseCasesTests
//{
//    using System;
//    using Microsoft.VisualStudio.TestTools.UnitTesting;
//    using StarJournalEntities.StarBusinessEntities;
//    using StarJournalUseCases.SaveItem;
//    using Utilities.DateTime;
//    using Utilities.IdGenerator;

//    [TestClass]
//    public class TestSaveItemFactory
//    {
//        [TestMethod]
//        [ExpectedException(typeof(ArgumentNullException))]
//        public void TestCtorArgumentNull()
//        {
//            SaveItemFactory factory = new SaveItemFactory(null);
//        }

//        [TestMethod]
//        [ExpectedException(typeof(ArgumentNullException))]
//        public void TestCreateArgumentNull()
//        {
//            //var subFactory = new StarBusinessEntityFactory(new IdClass(), new DateTimeClass());
//            //SaveItemFactory factory = null; // new SaveItemFactory(subFactory);
//            //ISaveStarItem saveStarItem = factory.Create(null);
//        }

//        [TestMethod]
//        [ExpectedException(typeof(ArgumentNullException))]
//        public void TestCreateEmptyArgument()
//        {
//            //var subFactory = new StarBusinessEntityFactory(new IdClass(), new DateTimeClass());
//            //var factory = new SaveItemFactory(subFactory);
//            //ISaveStarItem saveStarItem = factory.Create();

//            //saveStarItem.Execute();
//        }

//        private class IdClass : IGenerateId
//        {
//            string IGenerateId.Unique() => "myId";
//        }
//    }
//}
