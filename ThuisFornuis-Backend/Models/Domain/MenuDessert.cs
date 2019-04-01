using System;
namespace ThuisFornuis_Backend.Models
{
    public class MenuDessert
    {
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public int DessertId { get; set; }
        public Dessert Dessert { get; set; }
        public DateTime Datum { get; set; }
    }
}
