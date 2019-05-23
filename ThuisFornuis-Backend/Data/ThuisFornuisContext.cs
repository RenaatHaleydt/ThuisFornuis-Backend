using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ThuisFornuis_Backend.Models;
using ThuisFornuis_Backend.Models.Mappers;

namespace ThuisFornuis_Backend.Data
{
    public class ThuisFornuisContext : IdentityDbContext
    {
        
        public ThuisFornuisContext(DbContextOptions<ThuisFornuisContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            //Hier mappen we de dingen!!!!!!
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new MenuConfiguration());
            builder.ApplyConfiguration(new MenuGerechtConfiguration());
            builder.ApplyConfiguration(new MenuSoepConfiguration());
            builder.ApplyConfiguration(new MenuDessertConfiguration());
            builder.ApplyConfiguration(new GerechtConfiguration());
            builder.ApplyConfiguration(new SoepConfiguration());
            builder.ApplyConfiguration(new DessertConfiguration());

            //Another way to seed the database
            builder.Entity<Menu>().HasData(
                new Menu { Id = 1, Datum = DateTime.Now.AddMonths(3), Omschrijving = "Dit is de eerste menu dat mama gekookt zal hebben" },
                new Menu { Id = 2, Datum = DateTime.Now.AddDays(14), Omschrijving = "Dit is de tweede menu die mama gemaakt heeft!" },
                new Menu { Id = 3, Datum = DateTime.Now.AddDays(31), Omschrijving = "Dit is een voorlopige menu! "}
            );

            builder.Entity<Gerecht>().HasData(
                //Shadow property can be used for the foreign key, in combination with anaonymous objects
                new { Id = 1, Naam = "Spaghetti", Prijs = (double)8.5, Hoeveelheid = (double)1, Omschrijving  = "De lekkerste spaghetti bolognese die je geproefd zal hebben" },
                new { Id = 2, Naam = "Hespenrolletjes met witloof in de kaassaus, samen met puree", Prijs = (double)8.5, Hoeveelheid = (double)1, Omschrijving = "Met verse groenten uit de tuin" },
                new { Id = 3, Naam = "Aardappelschotel met burgers, feta en kerstomaatjes", Prijs = (double)9, Hoeveelheid = (double)1, Omschrijving = "Feest op je bord" },
                new { Id = 4, Naam = "Parelcouscous met kippenfilet, een slaatje met kruidenyoghurtsausje", Prijs = (double)9, Hoeveelheid = (double)1, Omschrijving = "De parelcouscous is een soort pasta" },
                new { Id = 5, Naam = "Wortelpuree met braadworst", Prijs = (double)9, Hoeveelheid = (double)1, Omschrijving = "De famous wortelpuree van KSA Berlare" },
                new { Id = 6, Naam = "Schelvis met prei en aardappel uit de oven", Prijs = (double)9, Hoeveelheid = (double)1, MenuId = 2 }
            );

            builder.Entity<Soep>().HasData(
                new { Id = 1, Naam = "Groentensoep", Prijs = (double)2, Hoeveelheid = (double)0.5 },
                new { Id = 2, Naam = "Tomatensoep met balletjes", Prijs = (double)2.5, Hoeveelheid = (double)0.5 },
                new { Id = 3, Naam = "Gebraden paprikasoep", Prijs = (double)1.5, Hoeveelheid = (double)0.5 }
            );

            builder.Entity<Dessert>().HasData(
                new { Id = 1, Naam = "Chocomousse", Prijs = (double)2, Hoeveelheid = (double)1 },
                new { Id = 2, Naam = "Potje panna cotta met chocolade", Prijs = (double)1.5, Hoeveelheid = (double)1 },
                new { Id = 3, Naam = "Appeltaart met kaneel", Prijs = (double)2, Hoeveelheid = (double)1 }
            );
        }

        
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Gerecht> Gerechten { get; set; }
        public DbSet<Soep> Soepen { get; set; }
        public DbSet<Dessert> Desserts { get; set; }
    }
}
