namespace BusinessEntitiesRepositoryTests
{
    using System;
    using BusinessEntitiesRepository;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StarJournalUseCases.Dto;
    using StarJournalUseCases.Gateway;

    [TestClass]
    
    public class TestStarRepositoryGateway
    {
        [TestMethod]
        public void TestSaveStarItem()
        {
            // var connection = new SqliteConnection("DataSource=:memory:");

            var factory = new StarRepositoryGatewaySqlServerFactory();

            IStarRepositoryGateway gateWay = factory.CreateSqLite();

           gateWay.StoreStarItem(new StarItemDto() { Id = Guid.NewGuid(), ItemName = "Hello" });
        }
    }    
}
