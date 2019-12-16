namespace BusinessEntitiesRepository
{
    using System;
    using System.Configuration;
    using BusinessEntitiesRepository.DataBaseAccess;
    using Microsoft.Data.Sqlite;
    using Microsoft.EntityFrameworkCore;
    using StarJournalUseCases.Gateway;

    public class StarRepositoryGatewaySqlServerFactory
    {
        public IStarRepositoryGateway CreateSqlServer()
        {
            var dbOptionsBuilder = new DbContextOptionsBuilder<DbContextImpl>();
            string connectionString = ConfigurationManager.ConnectionStrings["StarJournalDB"].ConnectionString;
            if (String.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("ConnectionString for StarJournalDB is not valid.");
            }

            _ = dbOptionsBuilder.UseSqlServer(connectionString);

            var context = new DbContextImpl(dbOptionsBuilder.Options);

            return new StarRepositoryGateway(new UnitOfWork(context));
        }

        public IStarRepositoryGateway CreateSqLite()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            DbContextOptions<DbContextImpl> dbOptionsBuilder = new DbContextOptionsBuilder<DbContextImpl>()
                    .UseSqlite(connection)
                    .Options;

            DbContext context = new DbContextImpl(dbOptionsBuilder);

            return new StarRepositoryGateway(new UnitOfWork(context));
        }
    }
}
