namespace Framework.Core.Persistence
{
    public interface IDbContext : IDisposable
    {
        bool HasAnyThingToSave();
        int SaveChanges();
        void Migrate();
        bool EnsureCreated();
        bool EnsureDeleted();
    }
}
