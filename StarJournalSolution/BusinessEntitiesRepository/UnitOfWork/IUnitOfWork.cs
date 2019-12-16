namespace BusinessEntitiesRepository
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        IStarItemRepository StarItems { get; }

        int Complete();
    }
}
