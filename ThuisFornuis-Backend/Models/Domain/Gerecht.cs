using System;
using System.ComponentModel.DataAnnotations;

namespace ThuisFornuis_Backend.Models
{
    public class Gerecht
    {
        public int Id { get; set; }

        [Required]
        public string Naam { get; set; }

        [Required]
        public double Prijs { get; set; }

        [Required]
        public double Hoeveelheid { get; set; }

        public string Omschrijving { get; set; }

        public string Foto { get; set; }

        public Gerecht() { }

        public Gerecht(string naam, double prijs, double hoeveelheid, string omschrijving, string foto) {
            Naam = naam;
            Prijs = prijs;
            Hoeveelheid = hoeveelheid;
            Omschrijving = omschrijving == "" ? null: omschrijving;
            Foto = foto == "" ? null : foto;
        }
    }
}
