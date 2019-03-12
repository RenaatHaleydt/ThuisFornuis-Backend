using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ThuisFornuis_Backend.Models
{
    public class Menu
    {
        #region Properties
        public int Id { get; set; }

        [Required]
        public DateTime Datum { get; set; }

        public string Omschrijving { get; set; }

        public ICollection<Gerecht> Gerechten { get; private set; }

        public ICollection<Soep> Soepen { get; private set; }

        public ICollection<Dessert> Desserts { get; private set; }
        #endregion

        #region Constructors
        public Menu()
        {
            Gerechten = new List<Gerecht>();
            Soepen = new List<Soep>();
            Desserts = new List<Dessert>();
        }

        public Menu(DateTime datum, string omschrijving) : this()
        {
            Datum = datum;
            Omschrijving = omschrijving;
        }
        #endregion

        #region Methods
        public void AddGerecht(Gerecht gerecht) => Gerechten.Add(gerecht);

        public Gerecht GetGerecht(int id) => Gerechten.SingleOrDefault(i => i.Id == id);
        #endregion
    }

}
