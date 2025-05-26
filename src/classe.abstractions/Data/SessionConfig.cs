using ClassE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassE.Data
{
    internal class SessionConfig : IEntityTypeConfiguration<Entities.Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable("Sessions");

            builder.Property(p => p.RowVersion)
                .IsRowVersion();

            builder.HasMany(p => p.Attendees)
                .WithMany(p => p.Sessions)
                .UsingEntity("SessionAttendees");
        }
    }
}