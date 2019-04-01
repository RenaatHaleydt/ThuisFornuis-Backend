using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ThuisFornuis_Backend.Models;

namespace ThuisFornuis_Backend.DTOs
{
    public class SoepDTO
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

        static public SoepDTO MapSoep(MenuSoep menuSoep)
        {
            return new SoepDTO()
            {
                Id = menuSoep.SoepId,
                Datum = menuSoep.Datum,
                Naam = menuSoep.Soep.Naam,
                Prijs = menuSoep.Soep.Prijs,
                Hoeveelheid = menuSoep.Soep.Hoeveelheid,
                Omschrijving = menuSoep.Soep.Omschrijving,
                Foto = menuSoep.Soep.Foto
            };
        }
    }


}
