using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ThuisFornuis_Backend.Models;

namespace ThuisFornuis_Backend.DTOs
{
    public class DessertDTO
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

        static public DessertDTO MapDessert(MenuDessert menuDessert)
        {
            return new DessertDTO()
            {
                Id = menuDessert.DessertId,
                Datum = menuDessert.Datum,
                Naam = menuDessert.Dessert.Naam,
                Prijs = menuDessert.Dessert.Prijs,
                Hoeveelheid = menuDessert.Dessert.Hoeveelheid,
                Omschrijving = menuDessert.Dessert.Omschrijving,
                Foto = menuDessert.Dessert.Foto
            };
        }
    }


}
