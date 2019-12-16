namespace StarJournalEntities.StarBusinessEntities
{
    using System;

    public interface IStarBusinessEntity
    {
        Guid Id { get; }
        bool IsNew { get; }
        string ItemName { get; }

        void CreateNewStarItem(Guid id);
    }
}