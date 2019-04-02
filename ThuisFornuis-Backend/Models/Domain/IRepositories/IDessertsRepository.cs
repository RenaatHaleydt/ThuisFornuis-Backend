using System;
using System.Collections.Generic;

namespace ThuisFornuis_Backend.Models.Domain.IRepositories
{
    public interface IDessertsRepository
    {
        Dessert GetBy(int id);
        bool TryGetDessert(int id, out Dessert dessert);
        IEnumerable<Dessert> GetAll();
        void Add(Dessert dessert);
        void Delete(Dessert dessert);
        void Update(Dessert dessert);
        void SaveChanges();

    }
}
