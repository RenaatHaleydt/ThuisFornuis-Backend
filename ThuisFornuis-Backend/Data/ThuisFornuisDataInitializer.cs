using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ThuisFornuis_Backend.Models;

namespace ThuisFornuis_Backend.Data
{
    public class ThuisFornuisDataInitializer
    {
        private readonly ThuisFornuisContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public ThuisFornuisDataInitializer(ThuisFornuisContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task InitializeData()
        {
            //_dbContext.Database.EnsureDeleted();
            // if (_dbContext.Database.EnsureCreated())
            // {
                //seeding the database with menus, see DBContext
                //var menus = _dbContext.Menus;
                //var gerechten = _dbContext.Gerechten;
                //var soepen = _dbContext.Soepen;
                //var desserts = _dbContext.Desserts;
                //int tellerGerechten = 1;
                //int tellerRest = 1;

                //foreach(var menu in menus)
                //{
                //    menu.AddGerecht(gerechten.Find(tellerGerechten), DateTime.Now);
                //    menu.AddGerecht(gerechten.Find(tellerGerechten + 1), DateTime.Now);
                //    menu.AddSoep(soepen.Find(tellerRest), DateTime.Now);
                //    menu.AddDessert(desserts.Find(tellerRest), DateTime.Now);
                //    tellerGerechten = tellerGerechten + 2;
                //    tellerRest = tellerRest + 1;
                //}

                //await CreateUser("renaat.haleydt.y066@hogent.be", "P@ssword1234");
                await CreateUser("web4", "gelukkiggeennetbeans");

                _dbContext.SaveChanges();
            // }
        }

        private async Task CreateUser(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(user, password);
        }
    }
}
