namespace StarJournalUseCases.AddItem
{
    using StarJournalEntities.StarBusinessEntities;
    using StarJournalUseCases.Dto;
    using StarJournalUseCases.Interfaces;
    using Utilities.IdGenerator;

    public sealed class AddItemInteractor : IAddStarItemInputPort
    {
        private readonly IStarBusinessEntity StarItemBusinessLogic;
        private readonly IGenerateId IdGenerator;

        public IStarItemOutputPort OutputBoundary { get; private set; }

        internal AddItemInteractor(
            IGenerateId idGenerator,
            IStarBusinessEntity starBl)
        {
            this.StarItemBusinessLogic = starBl;
            this.IdGenerator = idGenerator;
            this.OutputBoundary = new NoOutputBoundary();
        }

        void IAddStarItemInputPort.BindOutputBoundary(IStarItemOutputPort outputPort)
        {
            this.OutputBoundary = outputPort;
        }

        void IUseCase.Execute()
        {
            // To add a star item, I need to
            // -- Create a new STAR business object with the correct properties.
            // -- Send a response model with the ID of the STAR item
            this.CreateNewStarItem();
            this.SendResponseModel();
        }

        private void CreateNewStarItem()
        {
            this.StarItemBusinessLogic.CreateNewStarItem(this.IdGenerator.Unique());
        }

        private void SendResponseModel()
        {
            var data = new StarItemDto()
            {
                Id = this.StarItemBusinessLogic.Id,
                IsNew = this.StarItemBusinessLogic.IsNew,
                ItemName=this.StarItemBusinessLogic.ItemName,
            };

            this.OutputBoundary.Created(data);
        }

        
        private class NoOutputBoundary : IStarItemOutputPort
        {
            void IStarItemOutputPort.Created(StarItemDto data)
            { // Do Nothing. 
            }              
        }
    }
}
