using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassE.Data
{
    internal class VenueConfig : IEntityTypeConfiguration<Entities.Venue>
    {
        public void Configure(EntityTypeBuilder<Entities.Venue> builder)
        {
            builder.ToTable("Venues");

            builder.Property(p => p.RowVersion)
                .IsRowVersion();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Email)
                .HasMaxLength(200);

            builder.Property(p => p.Phone)
                .HasMaxLength(16);
        }
    }
}