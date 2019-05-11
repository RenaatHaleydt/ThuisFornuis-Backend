using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ThuisFornuis_Backend.DTOs;
using ThuisFornuis_Backend.Models;
using ThuisFornuis_Backend.Models.Domain.IRepositories;

namespace ThuisFornuis_Backend.Data.Repositories
{
    public class GerechtenRepository : IGerechtenRepository
    {
        private readonly ThuisFornuisContext _context;
        private readonly DbSet<Gerecht> _gerechten;

        public GerechtenRepository(ThuisFornuisContext dbContext)
        {
            _context = dbContext;
            _gerechten = dbContext.Gerechten;
        }

        public IEnumerable<Gerecht> GetAll()
        {
            return _gerechten
                    .OrderBy(g => g.Naam)
                    .ToList();
        }

        public Gerecht GetBy(int id)
        {
            return _gerechten
                    .SingleOrDefault(g => g.Id == id);
        }

        public IEnumerable<Gerecht> GetBy(string naam = null, string omschrijving = null)
        {
            var gerechten = _gerechten.AsQueryable();
            if (!string.IsNullOrEmpty(naam))
                gerechten = gerechten.Where(g => g.Naam.IndexOf(naam, System.StringComparison.OrdinalIgnoreCase) >= 0);
            if (!string.IsNullOrEmpty(omschrijving))
                gerechten = gerechten.Where(g => g.Omschrijving!= null && g.Omschrijving.Equals(omschrijving, System.StringComparison.OrdinalIgnoreCase));

            return gerechten
                        .OrderBy(g => g.Naam)
                        .ToList();
        }

        public bool TryGetGerecht(int id, out Gerecht gerecht)
        {
            gerecht = _context.Gerechten
                    .FirstOrDefault(g => g.Id == id);
            return gerecht != null;
        }

        public void Add(Gerecht gerecht)
        {
            _gerechten.Add(gerecht);
        }

        public void Update(Gerecht toUpdateGerecht)
        {
            var gerecht = _gerechten.FirstOrDefault(g => g.Id == toUpdateGerecht.Id);

            if (gerecht != null)
            {
                _context.Update(toUpdateGerecht);
            }
        }

        public void Delete(Gerecht gerecht)
        {
            _gerechten.Remove(gerecht);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
