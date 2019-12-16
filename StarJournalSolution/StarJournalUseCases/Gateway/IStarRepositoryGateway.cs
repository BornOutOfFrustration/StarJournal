namespace StarJournalUseCases.Gateway
{
    using System;
    using StarJournalUseCases.Dto;

    public interface IStarRepositoryGateway : IDisposable
    {
        void StoreStarItem(StarItemDto data);
    }
}
