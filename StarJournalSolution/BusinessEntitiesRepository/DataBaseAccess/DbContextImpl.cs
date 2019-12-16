namespace BusinessEntitiesRepository.DataBaseAccess
{
    using BusinessEntitiesRepository.DatabaseObjects;
    using Microsoft.EntityFrameworkCore;
    
    public sealed class DbContextImpl : DbContext
    {
        //public class X : DiagnosticSource
        //{
        //    public override bool IsEnabled(string name)
        //    {
        //        throw new System.NotImplementedException();
        //    }

        //    public override void Write(string name, object value)
        //    {
        //        throw new System.NotImplementedException();
        //    }
        //}

        public DbContextImpl(DbContextOptions<DbContextImpl> options)
        : base(options)
        {
            //// THIS IS NEEDED FOR RUNTIME :-(
            //var x = new X();
            //var y = StringSegmentComparer.Ordinal;

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            _ = modelBuilder
                .Entity<StarItemDbo>()
                .ToTable("StarItems");

            _ = modelBuilder.Entity<StarItemDbo>(entity =>
              {
                  _ = entity
                      .Property(e => e.Id)
                      .ValueGeneratedNever();

                  _ = entity
                      .Property(e => e.ItemName)
                      .HasColumnName("Name")
                      .IsRequired()
                      .HasColumnType("ntext");
              });

            base.OnModelCreating(modelBuilder);
        }
    }
}
