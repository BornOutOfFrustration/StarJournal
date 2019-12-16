namespace StarJournalTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StarJournalEntities.StarBusinessEntities;
    using StarJournalUseCases.AddItem;
    using StarJournalUseCases.Dto;
    using Utilities.IdGenerator;

    [TestClass]
    public class AddItemTest
    {
        [TestMethod]
        public void TestAddItemExecute()
        {
            // ARRANGE
            var businessEntityFactory = new StarBusinessEntityFactory();
            IStarBusinessEntity businessEntity = businessEntityFactory.Create();

            var usecaseFactory = new AddItemUsecaseFactory(new IdClass());                

            StarItemDto data = null;

            var returnInterface = new ItemCreated();
            returnInterface.Created += (s, e) =>
            {
                data = new StarItemDto
                {
                    Id = e.Id,
                    IsNew = e.IsNew,
                    ItemName = e.ItemName
                };
            };

            IAddStarItemInputPort addItemInterActor = usecaseFactory.Create(businessEntity);
            addItemInterActor.BindOutputBoundary(returnInterface);

            // ACT
            addItemInterActor.Execute();

            // ASSERT
            Assert.IsNotNull(data, "StarItemCreated return interface did not return data.");
            Assert.AreEqual(Guid.Parse(@"01234567-89ab-cdef-0000-0123456789AB"), data.Id);
            Assert.IsTrue(data.IsNew);
            Assert.AreEqual(String.Empty, data.ItemName);
        }

        private class ItemCreated : IStarItemOutputPort
        {
            public event EventHandler<StarItemDto> Created;

            void IStarItemOutputPort.Created(StarItemDto data)
            {
                this.Created?.Invoke(this, data);
            }
        }

        private class IdClass : IGenerateId
        {
            Guid IGenerateId.Unique()
            {
                return Guid.Parse(@"01234567-89ab-cdef-0000-0123456789AB");
            }
        }
    }
}
