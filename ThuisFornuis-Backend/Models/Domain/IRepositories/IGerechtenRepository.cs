using System;
using System.Collections.Generic;

namespace ThuisFornuis_Backend.Models.Domain.IRepositories
{
    public interface IGerechtenRepository
    {
        Gerecht GetBy(int id);
        IEnumerable<Gerecht> GetBy(string naam, string omschrijving);
        bool TryGetGerecht(int id, out Gerecht gerecht);
        IEnumerable<Gerecht> GetAll();
        void Add(Gerecht soep);
        void Delete(Gerecht soep);
        void Update(Gerecht soep);
        void SaveChanges();

    }
}
