﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThuisFornuis_Backend.Models {
    public class Dessert {
        public int Id { get; set; }

        [Required]
        public string Naam { get; set; }

        [Required]
        public double Prijs { get; set; }

        public double Hoeveelheid { get; set; }

        public string Omschrijving { get; set; }

        public string Foto { get; set; }

        public Dessert(string naam, double prijs, double hoeveelheid, string omschrijving = null, string foto = null) {
            Naam = naam;
            Prijs = prijs;
            Hoeveelheid = hoeveelheid;
            Omschrijving = omschrijving;
            Foto = foto;
        }
    }
}
