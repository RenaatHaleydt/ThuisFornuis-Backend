using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ThuisFornuis_Backend.Models;

namespace ThuisFornuis_Backend.DTOs
{
    public class MenuDTO
    {
        public int Id { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime Datum { get; set; }

        public string Omschrijving { get; set; }

        public IList<GerechtDTO> Gerechten { get; set; }

        public IList<SoepDTO> Soepen { get; set; }

        public IList<DessertDTO> Desserts { get; set; }

        static public MenuDTO MapMenu(Menu menu)
        {
            return new MenuDTO()
            {
                Id = menu.Id,
                Datum = menu.Datum,
                Omschrijving = menu.Omschrijving,
                Gerechten = menu.MenuGerechten.Select(menuGerecht => GerechtDTO.MapGerecht(menuGerecht)).ToList(),
                Soepen = menu.MenuSoepen.Select(menuSoep => SoepDTO.MapSoep(menuSoep)).ToList(),
                Desserts = menu.MenuDesserts.Select(menuDessert => DessertDTO.MapDessert(menuDessert)).ToList()
            };
        }
    }
}
