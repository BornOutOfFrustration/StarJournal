namespace StarJournalEntitiesTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StarJournalEntities.StarBusinessEntities;

    [TestClass]
    public class TestStarBusinessEntity
    {
        [TestMethod]
        public void TestCreateNewStarItem()
        {
            var factory = new StarBusinessEntityFactory();
            IStarBusinessEntity be = factory.Create();
            var id = Guid.NewGuid();

            be.CreateNewStarItem(id);

            Assert.IsTrue(be.IsNew);
            Assert.AreEqual(id, be.Id);
            Assert.AreEqual(String.Empty, be.ItemName);
        }
    }
}
