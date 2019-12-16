namespace StarJournalUseCases.SaveItem
{
    using StarJournalUseCases.Interfaces;

    public interface ISaveStarItemInputPort : IUseCase
    {
        void BindOutputBoundary(IStarItemSavedOutputPort outputPort);
        void SetName(string name);
    }
}
