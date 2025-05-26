using Microsoft.EntityFrameworkCore;

namespace ClassE.Data
{
    public interface IDataContext
    {
        DbSet<Entities.Class> Class { get; }
        DbSet<Entities.Person> People { get; }
        DbSet<Entities.Venue> Venues { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}