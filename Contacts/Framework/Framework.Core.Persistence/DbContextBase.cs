using Framework.Core.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Framework.Persistence
{
    public class DbContextBase : DbContext, IDbContext
    {
        protected DbContextBase(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
        public bool EnsureCreated()
        {
            return base.Database.EnsureCreated();
        }

        public bool EnsureDeleted()
        {
            return base.Database.EnsureDeleted();
        }

        public bool HasAnyThingToSave()
        {
            return ChangeTracker.Entries().Any(e => e.State == EntityState.Added
                                   || e.State == EntityState.Modified
                                   || e.State == EntityState.Deleted);
        }

        public void Migrate()
        {
            base.Database.Migrate();
        }

        public new int SaveChanges()
        {
            return base.SaveChanges();
        }
        public new Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
