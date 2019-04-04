using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ThuisFornuis_Backend.Models;
using ThuisFornuis_Backend.Models.Domain.IRepositories;

namespace ThuisFornuis_Backend.Data.Repositories
{
    public class SoepenRepository: ISoepenRepository
    {
        private readonly ThuisFornuisContext _context;
        private readonly DbSet<Soep> _soepen;

        public SoepenRepository(ThuisFornuisContext dbContext)
        {
            _context = dbContext;
            _soepen = dbContext.Soepen;
        }

        public IEnumerable<Soep> GetAll()
        {
            return _soepen
                    .OrderBy(s => s.Naam)
                    .ToList();
        }

        public Soep GetBy(int id)
        {
            return _soepen
                    .SingleOrDefault(s => s.Id == id);
        }

        public bool TryGetSoep(int id, out Soep soep)
        {
            soep = _context.Soepen
                    .FirstOrDefault(s => s.Id == id);
            return soep != null;
        }

        public void Add(Soep soep)
        {
            _soepen.Add(soep);
        }

        public void Update(Soep toUpdateSoep)
        {
            var soep = _soepen.FirstOrDefault(s => s.Id == toUpdateSoep.Id);

            if (soep != null)
            {
                _context.Update(soep);
            }

            //_context.Update(toUpdateMenu);
        }

        public void Delete(Soep soep)
        {
            _soepen.Remove(soep);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
