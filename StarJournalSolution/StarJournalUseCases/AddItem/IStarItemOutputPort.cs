namespace StarJournalUseCases.AddItem
{
    using StarJournalUseCases.Dto;

    public interface IStarItemOutputPort
    {
        void Created(StarItemDto data);
    }
}
