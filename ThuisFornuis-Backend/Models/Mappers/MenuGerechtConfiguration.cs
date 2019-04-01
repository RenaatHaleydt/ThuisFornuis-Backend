using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ThuisFornuis_Backend.Models.Mappers
{
    public class MenuGerechtConfiguration : IEntityTypeConfiguration<MenuGerecht>
    {
        public void Configure(EntityTypeBuilder<MenuGerecht> builder)
        {
            builder.HasKey(mg => new { mg.MenuId, mg.GerechtId });
            builder.HasOne(mg => mg.Menu).WithMany(m => m.MenuGerechten).HasForeignKey(mg => mg.MenuId).IsRequired();
            builder.HasOne(mg => mg.Gerecht).WithMany().HasForeignKey(mg => mg.GerechtId).IsRequired();
        }
    }
}
