namespace BusinessEntitiesRepository
{
    using System;
    using BusinessEntitiesRepository.DatabaseObjects;
    using StarJournalUseCases.Dto;
    using StarJournalUseCases.Gateway;

    internal class StarRepositoryGateway : IStarRepositoryGateway
    {
        private readonly IUnitOfWork Uow;

        internal StarRepositoryGateway(IUnitOfWork unitOfWork)
        {
            this.Uow = unitOfWork;
        }

        void IStarRepositoryGateway.StoreStarItem(StarItemDto data)
        {
            var item = Uow.StarItems.Get(data.Id);
            if(item == null)
            {
                var starItem = new StarItemDbo()
                {
                    Id = data.Id,
                    ItemName = data.ItemName,
                };

                Uow.StarItems.Add(starItem);
            }
            else
            {
                item.ItemName = data.ItemName;
            }

            Uow.Complete();
        }

        #region IDisposable Support
        private bool DisposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!DisposedValue)
            {
                if (disposing)
                {
                    Uow.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                DisposedValue = true;
            }
        }

        ~StarRepositoryGateway()
        {
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        void System.IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
