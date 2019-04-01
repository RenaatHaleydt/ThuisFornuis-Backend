using System;
using Microsoft.EntityFrameworkCore;
using ThuisFornuis_Backend.Models;

namespace ThuisFornuis_Backend.Data
{
    public class ThuisFornuisContext : DbContext
    {
        public ThuisFornuisContext(DbContextOptions<ThuisFornuisContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Hier mappen we de dingen!!!!!!
            base.OnModelCreating(modelBuilder);
            
            //Menu
            //modelBuilder.Entity<Menu>()
                //.HasMany(p => p.Gerechten)
                //.WithOne()
                //.IsRequired()
                //.HasForeignKey("MenuId"); //Shadow property
            modelBuilder.Entity<Menu>()
                .HasMany(m => m.Soepen)
                .WithOne()
                .IsRequired()
                .HasForeignKey("MenuId");
            modelBuilder.Entity<Menu>()
                .HasMany(m => m.Desserts)
                .WithOne()
                .IsRequired()
                .HasForeignKey("MenuId");
            modelBuilder.Entity<Menu>().Property(m => m.Datum).IsRequired();
            modelBuilder.Entity<Menu>().Property(m => m.Omschrijving).HasMaxLength(150);
            modelBuilder.Entity<Menu>().Ignore(m => m.Gerechten);

            modelBuilder.Entity<MenuGerecht>().HasKey(mg => new { mg.MenuId, mg.GerechtId });
            modelBuilder.Entity<MenuGerecht>().HasOne(mg => mg.Menu).WithMany(m => m.MenuGerechten).HasForeignKey(mg => mg.MenuId);
            modelBuilder.Entity<MenuGerecht>().HasOne(mg => mg.Gerecht).WithMany().HasForeignKey(mg => mg.GerechtId);

            //Gerecht
            modelBuilder.Entity<Gerecht>().Property(g => g.Naam).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Gerecht>().Property(g => g.Prijs).IsRequired();
            modelBuilder.Entity<Gerecht>().Property(g => g.Hoeveelheid).IsRequired();
            modelBuilder.Entity<Gerecht>().Property(g => g.Omschrijving).HasMaxLength(150);
            modelBuilder.Entity<Gerecht>().Property(g => g.Foto).HasMaxLength(100);

            //Soep
            modelBuilder.Entity<Soep>().Property(g => g.Naam).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Soep>().Property(g => g.Prijs).IsRequired();
            modelBuilder.Entity<Soep>().Property(g => g.Hoeveelheid).IsRequired();
            modelBuilder.Entity<Soep>().Property(g => g.Omschrijving).HasMaxLength(150);
            modelBuilder.Entity<Soep>().Property(g => g.Foto).HasMaxLength(100);

            //Dessert
            modelBuilder.Entity<Dessert>().Property(g => g.Naam).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Dessert>().Property(g => g.Prijs).IsRequired();
            modelBuilder.Entity<Dessert>().Property(g => g.Hoeveelheid).IsRequired();
            modelBuilder.Entity<Dessert>().Property(g => g.Omschrijving).HasMaxLength(150);
            modelBuilder.Entity<Dessert>().Property(g => g.Foto).HasMaxLength(100);


            //Another way to seed the database
            modelBuilder.Entity<Menu>().HasData(
                new Menu { Id = 1, Datum = DateTime.Now.AddMonths(3), Omschrijving = "Dit is de eerste menu dat mama gekookt zal hebben" },
                new Menu { Id = 2, Datum = DateTime.Now.AddDays(14), Omschrijving = "Dit is de tweede menu die mama gemaakt heeft!" },
                new Menu { Id = 3, Datum = DateTime.Now.AddDays(31), Omschrijving = "Dit is een voorlopige menu! "}
            );

            modelBuilder.Entity<Gerecht>().HasData(
                //Shadow property can be used for the foreign key, in combination with anaonymous objects
                new { Id = 1, Naam = "Spaghetti", Prijs = (double)8.5, Hoeveelheid = (double)1, Omschrijving  = "De lekkerste spaghetti bolognese die je geproefd zal hebben" },
                new { Id = 2, Naam = "Hespenrolletjes met witloof in de kaassaus, samen met puree", Prijs = (double)8.5, Hoeveelheid = (double)1, Omschrijving = "Met verse groenten uit de tuin" },
                new { Id = 3, Naam = "Aardappelschotel met burgers, feta en kerstomaatjes", Prijs = (double)9, Hoeveelheid = (double)1, Omschrijving = "Feest op je bord" },
                new { Id = 4, Naam = "Parelcouscous met kippenfilet, een slaatje met kruidenyoghurtsausje", Prijs = (double)9, Hoeveelheid = (double)1, Omschrijving = "De parelcouscous is een soort pasta" },
                new { Id = 5, Naam = "Wortelpuree met braadworst", Prijs = (double)9, Hoeveelheid = (double)1, Omschrijving = "De famous wortelpuree van KSA Berlare" },
                new { Id = 6, Naam = "Schelvis met prei en aardappel uit de oven", Prijs = (double)9, Hoeveelheid = (double)1, MenuId = 2 }
            );

            modelBuilder.Entity<Soep>().HasData(
                new { Id = 1, Naam = "Groentensoep", Prijs = (double)2, Hoeveelheid = (double)0.5, MenuId = 1 },
                new { Id = 2, Naam = "Tomatensoep met balletjes", Prijs = (double)2.5, Hoeveelheid = (double)0.5, MenuId = 2 },
                new { Id = 3, Naam = "Gebraden paprikasoep", Prijs = (double)1.5, Hoeveelheid = (double)0.5, MenuId = 3 }
            );

            modelBuilder.Entity<Dessert>().HasData(
                new { Id = 1, Naam = "Chocomousse", Prijs = (double)2, Hoeveelheid = (double)1, MenuId = 1 },
                new { Id = 2, Naam = "Potje panna cotta met chocolade", Prijs = (double)1.5, Hoeveelheid = (double)1, MenuId = 2 },
                new { Id = 3, Naam = "Appeltaart met kaneel", Prijs = (double)2, Hoeveelheid = (double)1, MenuId = 3 }
            );
        }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<Gerecht> Gerechten { get; set; }
        public DbSet<Soep> Soepen { get; set; }
        public DbSet<Dessert> Desserts { get; set; }
    }
}
