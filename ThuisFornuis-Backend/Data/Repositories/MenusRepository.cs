using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ThuisFornuis_Backend.Models;

namespace ThuisFornuis_Backend.Data.Repositories
{
    public class MenuRepository : IMenusRepository
    {
        private readonly ThuisFornuisContext _context;
        private readonly DbSet<Menu> _menus;

        public MenuRepository(ThuisFornuisContext dbContext)
        {
            _context = dbContext;
            _menus = dbContext.Menus;
        }

        public IEnumerable<Menu> GetAll()
        {
            return _menus
                    .Include(m => m.MenuGerechten)
                    .ThenInclude(mg => mg.Gerecht)
                    .OrderBy(m => m.Datum)
                    .ToList();
        }

        public Menu GetBy(int id)
        {
            return _menus
                    .Include(m => m.MenuGerechten)
                    .ThenInclude(mg => mg.Gerecht)
                    .SingleOrDefault(r => r.Id == id);
        }

        public bool TryGetMenu(int id, out Menu menu)
        {
            menu = _context.Menus
                    .Include(m => m.MenuGerechten)
                    .ThenInclude(mg => mg.Gerecht)
                    .FirstOrDefault(t => t.Id == id);
            return menu != null;
        }

        public void Add(Menu menu)
        {
            _menus.Add(menu);
        }

        public void Update(Menu toUpdateMenu)
        {
            //var menu = _menus.FirstOrDefault(m => m.Id == toUpdateMenu.Id);

            //if(menu != null) {
            //    _context.Update(menu);
            //}

            _context.Update(toUpdateMenu);
        }

        public void Delete(Menu menu)
        {
            _menus.Remove(menu);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
