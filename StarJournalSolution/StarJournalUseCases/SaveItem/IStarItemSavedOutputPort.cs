namespace StarJournalUseCases.SaveItem
{
    using System;
    using StarJournalUseCases.Dto;

    public interface IStarItemSavedOutputPort
    {
        void Notify(StarItemDto data);
    }
}
