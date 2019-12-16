namespace StarJournalUseCases.SaveItem
{
    using System;
    using StarJournalEntities.StarBusinessEntities;
    using StarJournalUseCases.Gateway;

    public class SaveItemFactory
    {
        public ISaveStarItemInputPort Create(
            IStarBusinessEntity starBusinessEntity, 
            IStarRepositoryGateway starRepositoryGateway)
        {
            return new SaveItemInteractor(starRepositoryGateway, starBusinessEntity);
        }
    }
}
