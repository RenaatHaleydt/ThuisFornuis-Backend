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
    }
}
