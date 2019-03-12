using System;
using System.Collections.Generic;

namespace ThuisFornuis_Backend.Models
{
    public interface IMenusRepository
    {
        Menu GetBy(int id);
        bool TryGetMenu(int id, out Menu menu);
        IEnumerable<Menu> GetAll();
        void Add(Menu menu);
        void Delete(Menu menu);
        void Update(Menu menu);
        void SaveChanges();
    }
}
