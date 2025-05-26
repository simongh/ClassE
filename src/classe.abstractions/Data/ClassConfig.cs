using ClassE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassE.Data
{
    internal class ClassConfig : IEntityTypeConfiguration<Entities.Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("Classes");

            builder.Property(p => p.RowVersion)
                .IsRowVersion();
        }
    }
}