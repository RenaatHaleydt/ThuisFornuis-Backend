using System;
using System.Collections.Generic;
using ThuisFornuis_Backend.Models;

namespace ThuisFornuis_Backend.Data
{
    public class ThuisFornuisDataInitializer
    {
        private readonly ThuisFornuisContext _dbContext;

        public ThuisFornuisDataInitializer(ThuisFornuisContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                //seeding the database with menus, see DBContext
                Menu menu = _dbContext.Menus.Find(1);
                menu.AddGerecht(new Gerecht("Nieuw gerecht", 3, 4, "", ""), DateTime.Now);
                //menu.AddDessert(_dbContext.Desserts.Find(1), DateTime.Now);
                _dbContext.SaveChanges();
            }
        }
    }
}
