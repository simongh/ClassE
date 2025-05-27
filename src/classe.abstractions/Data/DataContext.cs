using Microsoft.EntityFrameworkCore;

namespace ClassE.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<Entities.Booking> Bookings => Set<Entities.Booking>();

        public DbSet<Entities.Person> People => Set<Entities.Person>();

        public DbSet<Entities.Class> Classes => Set<Entities.Class>();

        public DbSet<Entities.Payment> Payments => Set<Entities.Payment>();

        public DbSet<Entities.Session> Sessions => Set<Entities.Session>();

        public DbSet<Entities.Venue> Venues => Set<Entities.Venue>();

        public DataContext() : base()
        { }

        public DataContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new BookingConfig())
                .ApplyConfiguration(new ClassConfig())
                .ApplyConfiguration(new PaymentConfig())
                .ApplyConfiguration(new PersonConfig())
                .ApplyConfiguration(new SessionConfig())
                .ApplyConfiguration(new VenueConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}