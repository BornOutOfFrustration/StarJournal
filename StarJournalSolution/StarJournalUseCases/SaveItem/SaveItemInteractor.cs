namespace StarJournalUseCases.SaveItem
{
    using System;
    using StarJournalEntities.StarBusinessEntities;
    using StarJournalUseCases.Dto;
    using StarJournalUseCases.Gateway;
    using StarJournalUseCases.Interfaces;

    internal class SaveItemInteractor : ISaveStarItemInputPort
    {
        private IStarItemSavedOutputPort OutputBoundary;
        private readonly IStarRepositoryGateway EntityGateway;
        private readonly IStarBusinessEntity StarItemBusinessLogic;

        public SaveItemInteractor(
            IStarRepositoryGateway entityGateway,
            IStarBusinessEntity starBl)
        {
            this.EntityGateway = entityGateway;
            this.StarItemBusinessLogic = starBl;
            this.OutputBoundary = new NoOutputBoundary();
        }

        void ISaveStarItemInputPort.BindOutputBoundary(IStarItemSavedOutputPort outputPort)
        {
            this.OutputBoundary = outputPort;
        }

        void IUseCase.Execute()
        {
            // To save the current star item, I need to:
            // --> Retreive all information
            // --> Save the information in the database.
            var dto = this.RetreiveAllInformation();
            this.SaveInformation(dto);
        }

        private StarItemDto RetreiveAllInformation()
        {
            return new StarItemDto()
            {
                Id = this.StarItemBusinessLogic.Id,
                IsNew = this.StarItemBusinessLogic.IsNew,
                ItemName = this.LocalName,
            };
        }

        private void SaveInformation(StarItemDto data)
        {
            this.EntityGateway.StoreStarItem(data);
            this.OutputBoundary.Notify(data);
        }

        private string LocalName = String.Empty;
        void ISaveStarItemInputPort.SetName(string name)
        {
            LocalName = name;
        }

        private class NoOutputBoundary : IStarItemSavedOutputPort
        {
            void IStarItemSavedOutputPort.Notify(StarItemDto data)
            { ; }
        }
    }
}
