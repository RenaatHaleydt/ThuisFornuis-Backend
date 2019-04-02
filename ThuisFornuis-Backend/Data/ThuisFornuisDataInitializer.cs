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
                var menus = _dbContext.Menus;
                var gerechten = _dbContext.Gerechten;
                var soepen = _dbContext.Soepen;
                var desserts = _dbContext.Desserts;
                int tellerGerechten = 1;
                int tellerRest = 1;

                foreach(var menu in menus)
                {
                    menu.AddGerecht(gerechten.Find(tellerGerechten), DateTime.Now);
                    menu.AddGerecht(gerechten.Find(tellerGerechten + 1), DateTime.Now);
                    menu.AddSoep(soepen.Find(tellerRest), DateTime.Now);
                    menu.AddDessert(desserts.Find(tellerRest), DateTime.Now);
                    tellerGerechten = tellerGerechten + 2;
                    tellerRest = tellerRest + 1;
                }
                _dbContext.SaveChanges();
            }
        }
    }
}
