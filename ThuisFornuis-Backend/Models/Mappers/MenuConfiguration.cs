using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ThuisFornuis_Backend.Models.Mappers
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.Property(m => m.Datum).IsRequired();
            builder.Property(m => m.Omschrijving).HasMaxLength(150);
            builder.Ignore(m => m.Gerechten);
        }
    }
}
