namespace BusinessEntitiesRepository
{
    using System;
    using Microsoft.EntityFrameworkCore;

    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext Database;

        internal UnitOfWork(DbContext starDatabase)
        {
            this.Database = starDatabase;
            this.LocalStarItems = new StarItemRepository(starDatabase);
        }

        private readonly IStarItemRepository LocalStarItems;
        IStarItemRepository IUnitOfWork.StarItems { get { return this.LocalStarItems; } }

        int IUnitOfWork.Complete()
        {
            if (this.DisposedValue)
            {
                throw new ObjectDisposedException(
                    nameof(UnitOfWork), 
                    $"Object is Disposed. Don't use {nameof(IUnitOfWork.Complete)} when object is disposed.");
            }

            return this.Database.SaveChanges();
        }

        #region IDisposable Support
        private bool DisposedValue = false; // To detect redundant calls

        private void Dispose(bool disposing)
        {
            if (!this.DisposedValue)
            {
                if (disposing)
                {
                    this.Database.Dispose();
                }

                this.DisposedValue = true;
            }
        }

        ~UnitOfWork()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            this.Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
