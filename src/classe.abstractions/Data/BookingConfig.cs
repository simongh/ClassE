using ClassE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassE.Data
{
    internal class BookingConfig : IEntityTypeConfiguration<Entities.Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Bookings");

            builder.Property(p => p.RowVersion)
                .IsRowVersion();
        }
    }
}