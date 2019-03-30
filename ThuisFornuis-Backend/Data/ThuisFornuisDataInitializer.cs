using System;
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
            }
        }
    }
}
