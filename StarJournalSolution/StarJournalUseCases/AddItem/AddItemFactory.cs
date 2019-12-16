namespace StarJournalUseCases.AddItem
{
    using System;
    using StarJournalEntities.StarBusinessEntities;
    using Utilities.IdGenerator;

    public class AddItemUsecaseFactory
    {
        private readonly IGenerateId IdGen;

        public AddItemUsecaseFactory(IGenerateId idGenerator)
        {
            this.IdGen = idGenerator 
                ?? throw new ArgumentNullException(
                    nameof(idGenerator), 
                    $"{nameof(AddItemUsecaseFactory)}.ctor() cannot take null as argument");
        }

        public IAddStarItemInputPort Create(
            IStarBusinessEntity starBusinessEntity)
        {
            if (starBusinessEntity == null)
            {
                throw new ArgumentNullException(
                    nameof(starBusinessEntity), 
                    $"{nameof(AddItemUsecaseFactory)}.{nameof(Create)} cannot take null as argument");
            }

            var addItemInteractor = new AddItemInteractor(
                this.IdGen,
                starBusinessEntity);

            return addItemInteractor;
        }
    }
}
