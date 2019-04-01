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


        public ICollection<MenuGerecht> MenuGerechten { get; private set; }
        public IEnumerable<Gerecht> Gerechten => MenuGerechten.Select(mg => mg.Gerecht);

        public ICollection<MenuSoep> MenuSoepen { get; private set; }
        public IEnumerable<Soep> Soepen => MenuSoepen.Select(ms => ms.Soep);

        public ICollection<MenuDessert> MenuDesserts { get; private set; }
        public IEnumerable<Dessert> Desserts => MenuDesserts.Select(md => md.Dessert);
        #endregion

        #region Constructors
        public Menu()
        {
            MenuGerechten = new List<MenuGerecht>();
            MenuSoepen = new List<MenuSoep>();
            MenuDesserts = new List<MenuDessert>();
        }

        public Menu(DateTime datum, string omschrijving) : this()
        {
            Datum = datum;
            Omschrijving = omschrijving;
        }

        public Menu(DateTime datum, string omschrijving, ICollection<MenuGerecht> menuGerechten)
        {
            Datum = datum;
            Omschrijving = omschrijving;
            MenuGerechten = menuGerechten;
            MenuSoepen = new List<MenuSoep>();
            MenuDesserts = new List<MenuDessert>();
        }

        public Menu(DateTime datum, string omschrijving, ICollection<MenuSoep> menuSoepen)
        {
            Datum = datum;
            Omschrijving = omschrijving;
            MenuGerechten = new List<MenuGerecht>();
            MenuSoepen = menuSoepen;
            MenuDesserts = new List<MenuDessert>();
        }

        public Menu(DateTime datum, string omschrijving, ICollection<MenuDessert> menuDesserts)
        {
            Datum = datum;
            Omschrijving = omschrijving;
            MenuGerechten = new List<MenuGerecht>();
            MenuSoepen = new List<MenuSoep>();
            MenuDesserts = menuDesserts;
        }

        public Menu(DateTime datum, string omschrijving, ICollection<MenuGerecht> menuGerechten, ICollection<MenuSoep> menuSoepen, ICollection<MenuDessert> menuDesserts)
        {
            Datum = datum;
            Omschrijving = omschrijving;
            MenuGerechten = menuGerechten;
            MenuSoepen = menuSoepen;
            MenuDesserts = menuDesserts;
        }
        #endregion

        #region Methods
        public void AddGerecht(Gerecht gerecht, DateTime datum) => MenuGerechten.Add(new MenuGerecht() { MenuId = Id, Menu = this, GerechtId = gerecht.Id, Gerecht = gerecht, Datum = datum });
        public Gerecht GetGerecht(int id) => MenuGerechten.SingleOrDefault(mg => mg.GerechtId == id).Gerecht;
        public void DeleteGerecht(Gerecht gerecht) => MenuGerechten.Remove(MenuGerechten.SingleOrDefault(mg => mg.GerechtId == gerecht.Id));

        public void AddSoep(Soep soep, DateTime datum) => MenuSoepen.Add(new MenuSoep() { MenuId = Id, Menu = this, SoepId = soep.Id, Soep = soep, Datum =  datum });
        public Soep GetSoep(int id) => MenuSoepen.SingleOrDefault(ms => ms.SoepId == id).Soep;
        public void DeleteSoep(Soep soep) => MenuSoepen.Remove(MenuSoepen.SingleOrDefault(ms => ms.SoepId == soep.Id));

        public void AddDessert(Dessert dessert, DateTime datum) => MenuDesserts.Add(new MenuDessert() { MenuId = Id, Menu = this, DessertId = dessert.Id, Dessert = dessert, Datum = datum });
        public Dessert GetDessert(int id) => MenuDesserts.SingleOrDefault(md => md.DessertId == id).Dessert;
        public void DeleteDessert(Dessert dessert) => MenuDesserts.Remove(MenuDesserts.SingleOrDefault(md => md.DessertId == dessert.Id));
        #endregion
    }

}
