using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ThuisFornuis_Backend.Models;

namespace ThuisFornuis_Backend.DTOs
{
    public class GerechtDTO
    {
        public int Id { get; set; }

        public DateTime Datum { get; set; }

        [Required]
        public string Naam { get; set; }

        [Required]
        public double Prijs { get; set; }

        [Required]
        public double Hoeveelheid { get; set; }

        public string Omschrijving { get; set; }

        public string Foto { get; set; }

        static public GerechtDTO MapGerecht(MenuGerecht menuGerecht)
        {
            return new GerechtDTO() 
            {
                Id = menuGerecht.GerechtId,
                Datum = menuGerecht.Datum,
                Naam = menuGerecht.Gerecht.Naam,
                Prijs = menuGerecht.Gerecht.Prijs,
                Hoeveelheid = menuGerecht.Gerecht.Hoeveelheid,
                Omschrijving = menuGerecht.Gerecht.Omschrijving,
                Foto = menuGerecht.Gerecht.Foto
            };
        }
    }


}
