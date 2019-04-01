using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThuisFornuis_Backend.DTOs
{
    public class MenuDTO
    {
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime Datum { get; set; }

        public string Omschrijving { get; set; }

        public IList<GerechtDTO> Gerechten { get; set; }

        public IList<SoepDTO> Soepen { get; set; }

        public IList<DessertDTO> Desserts { get; set; }
    }
}
