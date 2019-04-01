using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ThuisFornuis_Backend.Models.Mappers
{
    public class MenuDessertConfiguration : IEntityTypeConfiguration<MenuDessert>
    {
        public void Configure(EntityTypeBuilder<MenuDessert> builder)
        {
            builder.HasKey(md => new { md.MenuId, md.DessertId });
            builder.HasOne(md => md.Menu).WithMany(m => m.MenuDesserts).HasForeignKey(md => md.MenuId).IsRequired();
            builder.HasOne(md => md.Dessert).WithMany().HasForeignKey(md => md.DessertId).IsRequired();
        }
    }
}
