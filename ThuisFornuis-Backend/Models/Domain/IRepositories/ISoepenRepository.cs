using System;
using System.Collections.Generic;

namespace ThuisFornuis_Backend.Models.Domain.IRepositories
{
    public interface ISoepenRepository
    {
        Soep GetBy(int id);
        bool TryGetSoep(int id, out Soep soep);
        IEnumerable<Soep> GetAll();
        void Add(Soep soep);
        void Delete(Soep soep);
        void Update(Soep soep);
        void SaveChanges();
    
    }
}
