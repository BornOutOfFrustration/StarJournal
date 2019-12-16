using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarJournalEntities.StarBusinessEntities;
using StarJournalUseCases.AddItem;
using StarJournalUseCases.Dto;
using Utilities.DateTime;
using Utilities.IdGenerator;

namespace StarJournalUseCasesTests
{
    [TestClass]
    public class TestAddItemFactory
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCtorArgumentNull()
        {
            _ = new AddItemUsecaseFactory(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCreateArgumentNull()
        {
            var factory = new AddItemUsecaseFactory(new IdClass());
            IAddStarItemInputPort addStarItem = factory.Create(null);

            addStarItem.Execute();
        }

        [TestMethod]
        public void TestCreate()
        {
            var businessEntityFactory = new StarBusinessEntityFactory();
            IStarBusinessEntity businessEntity = businessEntityFactory.Create();

            var usecaseFactory = new AddItemUsecaseFactory(new IdClass());

            var outputBoundary = new Boundary();

            IAddStarItemInputPort addStarUseCase = usecaseFactory.Create(businessEntity);
            addStarUseCase.BindOutputBoundary(outputBoundary);

            addStarUseCase.Execute();

            Assert.IsTrue(outputBoundary.Triggered);
            Assert.IsTrue(outputBoundary.Data.IsNew);
        }

        private class Boundary : IStarItemOutputPort
        {
            public bool Triggered;
            public StarItemDto Data;

            void IStarItemOutputPort.Created(StarItemDto data)
            {
                this.Triggered = true;
                this.Data = data;
            }
        }

        private class IdClass : IGenerateId
        {
            Guid IGenerateId.Unique()
            {
                return Guid.NewGuid();
            }
        }
    }
}
