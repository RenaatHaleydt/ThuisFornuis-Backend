using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThuisFornuis_Backend.DTOs
{
    public class GerechtDTO
    {
        [Required]
        public string Naam { get; set; }

        [Required]
        public double Prijs { get; set; }

        [Required]
        public double Hoeveelheid { get; set; }

        public string Omschrijving { get; set; }

        public string Foto { get; set; }
    }


}
