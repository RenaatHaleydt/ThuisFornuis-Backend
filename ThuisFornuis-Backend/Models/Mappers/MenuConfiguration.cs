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
            //Gerechten, Soepen en Desserts mogen niet mee gemapt worden
            builder.Ignore(m => m.Gerechten);
            builder.Ignore(m => m.Soepen);
            builder.Ignore(m => m.Desserts);
        }
    }
}
