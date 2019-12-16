namespace BusinessEntitiesRepository
{
    using System;
    using BusinessEntitiesRepository.DatabaseObjects;
    using Microsoft.EntityFrameworkCore;

    //internal class StarDatabase : IStarDatabase
    //{
    //    private readonly DbContext Context;

    //    internal StarDatabase(DbContext context)
    //    {
    //        this.Context = context;
    //    }

    //    DbSet<StarItemDbo> IStarDatabase.StarItemSet => this.Context.Set<StarItemDbo>().Find();

    //    int IStarDatabase.SaveChanges()
    //    {
    //        if (this.DisposedValue)
    //        {
    //            throw new ObjectDisposedException(
    //                nameof(StarDatabase),
    //                $"Object is Disposed. Don't use {nameof(IStarDatabase.SaveChanges)} when object is disposed.");
    //        }
    //        return this.Context.SaveChanges();
    //    }

    //    #region IDisposable Support
    //    private bool DisposedValue = false; // To detect redundant calls

    //    protected virtual void Dispose(bool disposing)
    //    {
    //        if (!DisposedValue)
    //        {
    //            if (disposing)
    //            {
    //                this.Context.Dispose();
    //            }

    //            // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
    //            // TODO: set large fields to null.

    //            DisposedValue = true;
    //        }
    //    }

    //    // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
    //    // ~StarDatabase() {
    //    //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
    //    //   Dispose(false);
    //    // }

    //    // This code added to correctly implement the disposable pattern.
    //    void IDisposable.Dispose()
    //    {
    //        // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
    //        Dispose(true);
    //        // TODO: uncomment the following line if the finalizer is overridden above.
    //        // GC.SuppressFinalize(this);
    //    }

    //    DbSet<T> IStarDatabase.Set<T>()
    //    {
    //        return this.Context.Set<T>();
    //    }
    //    #endregion
    //}

    //public interface IStarDatabase : IDisposable
    //{
    //    int SaveChanges();

    //    DbSet<T> Set<T>() where T : class;

    //    DbSet<StarItemDbo> StarItemSet { get; }
    //}
}
