using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassE.Data
{
    internal class PersonConfig : IEntityTypeConfiguration<Entities.Person>
    {
        public void Configure(EntityTypeBuilder<Entities.Person> builder)
        {
            builder.ToTable("People");

            builder.Property(p => p.RowVersion)
                .IsRowVersion();

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Email)
                .HasMaxLength(200);

            builder.Property(p => p.Phone)
                .HasMaxLength(16);

            builder.HasMany(p => p.Sessions)
                .WithMany(p => p.Attendees)
                .UsingEntity("SessionAttendees");
        }
    }
}