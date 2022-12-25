namespace CapFive.Data.Repositories
{
    public abstract class RepositoryBase : IRepositoryBase
    {
        protected readonly CapFiveDbContext _db;

        protected RepositoryBase(CapFiveDbContext db)
        {
            _db = db;
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
