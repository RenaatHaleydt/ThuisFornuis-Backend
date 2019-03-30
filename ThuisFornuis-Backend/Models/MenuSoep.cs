using System;
namespace ThuisFornuis_Backend.Models
{
    public class MenuSoep
    {
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public int SoepId { get; set; }
        public Soep Soep { get; set; }
        public DateTime Datum { get; set; }

        public MenuSoep(Menu menu, Soep soep, DateTime datum)
        {
            this.Menu = menu;
            this.Soep = soep;
            this.Datum = datum;
        }
    }
}
