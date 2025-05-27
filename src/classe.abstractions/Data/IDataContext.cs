using ClassE.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassE.Data
{
    public interface IDataContext
    {
        DbSet<Entities.Class> Classes { get; }
        DbSet<Entities.Person> People { get; }
        DbSet<Entities.Venue> Venues { get; }
        DbSet<Booking> Bookings { get; }
        DbSet<Payment> Payments { get; }
        DbSet<Session> Sessions { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}