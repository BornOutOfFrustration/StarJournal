namespace StarJournalUseCases.AddItem
{
    using StarJournalUseCases.Interfaces;

    public interface IAddStarItemInputPort : IUseCase
    {
        void BindOutputBoundary(IStarItemOutputPort outputPort);
    }
}
