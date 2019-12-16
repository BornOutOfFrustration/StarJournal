namespace StarJournalGuiWpf
{
    using StarJournalUseCases.Interfaces;
    using StarJournalUseCases.SaveItem;

    public sealed class StarOverviewController : IStarOverviewController
    {
        private readonly IUseCase AddItemUsecase;
        private readonly ISaveStarItemInputPort SaveItemUsecase;

        public StarOverviewController(
            IUseCase addItemUsecase, 
            ISaveStarItemInputPort saveItemUsecase)
        {
            this.AddItemUsecase = addItemUsecase;
            this.SaveItemUsecase = saveItemUsecase;
        }

        void IStarOverviewController.AddStarItem()
        {
            this.AddItemUsecase.Execute();
        }

        void IStarOverviewController.SaveItem(string name)
        {
            this.SaveItemUsecase.SetName(name);
            this.SaveItemUsecase.Execute();
        }
    }
}