using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ThuisFornuis_Backend.Models.Mappers
{
    public class MenuSoepConfiguration : IEntityTypeConfiguration<MenuSoep>
    {
        public void Configure(EntityTypeBuilder<MenuSoep> builder)
        {
            builder.HasKey(mg => new { mg.MenuId, mg.SoepId });
            builder.HasOne(ms => ms.Menu).WithMany(m => m.MenuSoepen).HasForeignKey(ms => ms.MenuId).IsRequired();
            builder.HasOne(ms => ms.Soep).WithMany().HasForeignKey(ms => ms.SoepId).IsRequired();
        }
    }
}
