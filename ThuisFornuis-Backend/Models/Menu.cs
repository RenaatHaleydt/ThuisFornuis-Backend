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

        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
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

        public Menu(DateTime datum, string omschrijving, ICollection<Gerecht> gerechten)
        {
            Datum = datum;
            Omschrijving = omschrijving;
            Gerechten = gerechten;
            Soepen = new List<Soep>();
            Desserts = new List<Dessert>();
        }

        public Menu(DateTime datum, string omschrijving, ICollection<Soep> soepen)
        {
            Datum = datum;
            Omschrijving = omschrijving;
            Gerechten = new List<Gerecht>();
            Soepen = soepen;
            Desserts = new List<Dessert>();
        }

        public Menu(DateTime datum, string omschrijving, ICollection<Dessert> desserts)
        {
            Datum = datum;
            Omschrijving = omschrijving;
            Gerechten = new List<Gerecht>();
            Soepen = new List<Soep>();
            Desserts = desserts;
        }

        public Menu(DateTime datum, string omschrijving, ICollection<Gerecht> gerechten, ICollection<Soep> soepen, ICollection<Dessert> desserts)
        {
            Datum = datum;
            Omschrijving = omschrijving;
            Gerechten = gerechten;
            Soepen = soepen;
            Desserts = desserts;
        }
        #endregion

        #region Methods
        public void AddGerecht(Gerecht gerecht) => Gerechten.Add(gerecht);
        public Gerecht GetGerecht(int id) => Gerechten.SingleOrDefault(g => g.Id == id);
        public void DeleteGerecht(Gerecht gerecht) => Gerechten.Remove(gerecht);

        public void AddSoep(Soep soep) => Soepen.Add(soep);
        public Soep GetSoep(int id) => Soepen.SingleOrDefault(s => s.Id == id);
        public void DeleteSoep(Soep soep) => Soepen.Remove(soep);

        public void AddDessert(Dessert dessert) => Desserts.Add(dessert);
        public Dessert GetDessert(int id) => Desserts.SingleOrDefault(d => d.Id == id);
        public void DeleteDessert(Dessert dessert) => Desserts.Remove(dessert);
        #endregion
    }

}
