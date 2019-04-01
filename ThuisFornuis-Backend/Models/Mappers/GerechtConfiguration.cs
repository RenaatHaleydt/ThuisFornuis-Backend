﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ThuisFornuis_Backend.Models.Mappers
{
    public class GerechtConfiguration : IEntityTypeConfiguration<Gerecht>
    {
        public void Configure(EntityTypeBuilder<Gerecht> builder)
        {
            builder.Property(g => g.Naam).IsRequired().HasMaxLength(100);
            builder.Property(g => g.Prijs).IsRequired();
            builder.Property(g => g.Hoeveelheid).IsRequired();
            builder.Property(g => g.Omschrijving).HasMaxLength(150);
            builder.Property(g => g.Foto).HasMaxLength(100);
        }
    }
}
