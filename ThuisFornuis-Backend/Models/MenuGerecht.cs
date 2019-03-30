using System;
namespace ThuisFornuis_Backend.Models
{
    public class MenuGerecht
    {
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public int GerechtId { get; set; }
        public Gerecht Gerecht { get; set; }
        public DateTime Datum { get; set; }

        public MenuGerecht(Menu menu, Gerecht gerecht, DateTime datum)
        {
            this.Menu = menu;
            this.Gerecht = gerecht;
            this.Datum = datum;
        }
    }
}
