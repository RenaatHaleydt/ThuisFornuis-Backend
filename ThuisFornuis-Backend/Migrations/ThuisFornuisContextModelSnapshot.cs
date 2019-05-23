﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThuisFornuis_Backend.Data;

namespace ThuisFornuis_Backend.Migrations
{
    [DbContext(typeof(ThuisFornuisContext))]
    partial class ThuisFornuisContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ThuisFornuis_Backend.Models.Dessert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Foto")
                        .HasMaxLength(100);

                    b.Property<double>("Hoeveelheid");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Omschrijving")
                        .HasMaxLength(150);

                    b.Property<double>("Prijs");

                    b.HasKey("Id");

                    b.ToTable("Desserts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Hoeveelheid = 1.0,
                            Naam = "Chocomousse",
                            Prijs = 2.0
                        },
                        new
                        {
                            Id = 2,
                            Hoeveelheid = 1.0,
                            Naam = "Potje panna cotta met chocolade",
                            Prijs = 1.5
                        },
                        new
                        {
                            Id = 3,
                            Hoeveelheid = 1.0,
                            Naam = "Appeltaart met kaneel",
                            Prijs = 2.0
                        });
                });

            modelBuilder.Entity("ThuisFornuis_Backend.Models.Gerecht", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Foto")
                        .HasMaxLength(100);

                    b.Property<double>("Hoeveelheid");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Omschrijving")
                        .HasMaxLength(150);

                    b.Property<double>("Prijs");

                    b.HasKey("Id");

                    b.ToTable("Gerechten");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Hoeveelheid = 1.0,
                            Naam = "Spaghetti",
                            Omschrijving = "De lekkerste spaghetti bolognese die je geproefd zal hebben",
                            Prijs = 8.5
                        },
                        new
                        {
                            Id = 2,
                            Hoeveelheid = 1.0,
                            Naam = "Hespenrolletjes met witloof in de kaassaus, samen met puree",
                            Omschrijving = "Met verse groenten uit de tuin",
                            Prijs = 8.5
                        },
                        new
                        {
                            Id = 3,
                            Hoeveelheid = 1.0,
                            Naam = "Aardappelschotel met burgers, feta en kerstomaatjes",
                            Omschrijving = "Feest op je bord",
                            Prijs = 9.0
                        },
                        new
                        {
                            Id = 4,
                            Hoeveelheid = 1.0,
                            Naam = "Parelcouscous met kippenfilet, een slaatje met kruidenyoghurtsausje",
                            Omschrijving = "De parelcouscous is een soort pasta",
                            Prijs = 9.0
                        },
                        new
                        {
                            Id = 5,
                            Hoeveelheid = 1.0,
                            Naam = "Wortelpuree met braadworst",
                            Omschrijving = "De famous wortelpuree van KSA Berlare",
                            Prijs = 9.0
                        },
                        new
                        {
                            Id = 6,
                            Hoeveelheid = 1.0,
                            Naam = "Schelvis met prei en aardappel uit de oven",
                            Prijs = 9.0
                        });
                });

            modelBuilder.Entity("ThuisFornuis_Backend.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum");

                    b.Property<string>("Omschrijving")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Menus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Datum = new DateTime(2019, 8, 13, 16, 29, 39, 919, DateTimeKind.Local).AddTicks(6962),
                            Omschrijving = "Dit is de eerste menu dat mama gekookt zal hebben"
                        },
                        new
                        {
                            Id = 2,
                            Datum = new DateTime(2019, 5, 27, 16, 29, 39, 922, DateTimeKind.Local).AddTicks(7852),
                            Omschrijving = "Dit is de tweede menu die mama gemaakt heeft!"
                        },
                        new
                        {
                            Id = 3,
                            Datum = new DateTime(2019, 6, 13, 16, 29, 39, 922, DateTimeKind.Local).AddTicks(7878),
                            Omschrijving = "Dit is een voorlopige menu! "
                        });
                });

            modelBuilder.Entity("ThuisFornuis_Backend.Models.MenuDessert", b =>
                {
                    b.Property<int>("MenuId");

                    b.Property<int>("DessertId");

                    b.Property<DateTime>("Datum");

                    b.HasKey("MenuId", "DessertId");

                    b.HasIndex("DessertId");

                    b.ToTable("MenuDessert");
                });

            modelBuilder.Entity("ThuisFornuis_Backend.Models.MenuGerecht", b =>
                {
                    b.Property<int>("MenuId");

                    b.Property<int>("GerechtId");

                    b.Property<DateTime>("Datum");

                    b.HasKey("MenuId", "GerechtId");

                    b.HasIndex("GerechtId");

                    b.ToTable("MenuGerecht");
                });

            modelBuilder.Entity("ThuisFornuis_Backend.Models.MenuSoep", b =>
                {
                    b.Property<int>("MenuId");

                    b.Property<int>("SoepId");

                    b.Property<DateTime>("Datum");

                    b.HasKey("MenuId", "SoepId");

                    b.HasIndex("SoepId");

                    b.ToTable("MenuSoep");
                });

            modelBuilder.Entity("ThuisFornuis_Backend.Models.Soep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Foto")
                        .HasMaxLength(100);

                    b.Property<double>("Hoeveelheid");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Omschrijving")
                        .HasMaxLength(150);

                    b.Property<double>("Prijs");

                    b.HasKey("Id");

                    b.ToTable("Soepen");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Hoeveelheid = 0.5,
                            Naam = "Groentensoep",
                            Prijs = 2.0
                        },
                        new
                        {
                            Id = 2,
                            Hoeveelheid = 0.5,
                            Naam = "Tomatensoep met balletjes",
                            Prijs = 2.5
                        },
                        new
                        {
                            Id = 3,
                            Hoeveelheid = 0.5,
                            Naam = "Gebraden paprikasoep",
                            Prijs = 1.5
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ThuisFornuis_Backend.Models.MenuDessert", b =>
                {
                    b.HasOne("ThuisFornuis_Backend.Models.Dessert", "Dessert")
                        .WithMany()
                        .HasForeignKey("DessertId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ThuisFornuis_Backend.Models.Menu", "Menu")
                        .WithMany("MenuDesserts")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ThuisFornuis_Backend.Models.MenuGerecht", b =>
                {
                    b.HasOne("ThuisFornuis_Backend.Models.Gerecht", "Gerecht")
                        .WithMany()
                        .HasForeignKey("GerechtId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ThuisFornuis_Backend.Models.Menu", "Menu")
                        .WithMany("MenuGerechten")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ThuisFornuis_Backend.Models.MenuSoep", b =>
                {
                    b.HasOne("ThuisFornuis_Backend.Models.Menu", "Menu")
                        .WithMany("MenuSoepen")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ThuisFornuis_Backend.Models.Soep", "Soep")
                        .WithMany()
                        .HasForeignKey("SoepId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
