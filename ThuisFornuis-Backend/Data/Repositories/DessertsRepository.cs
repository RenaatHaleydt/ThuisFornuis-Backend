using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ThuisFornuis_Backend.Models;
using ThuisFornuis_Backend.Models.Domain.IRepositories;

namespace ThuisFornuis_Backend.Data.Repositories
{
    public class DessertsRepository: IDessertsRepository
    {
        private readonly ThuisFornuisContext _context;
        private readonly DbSet<Dessert> _desserts;

        public DessertsRepository(ThuisFornuisContext dbContext)
        {
            _context = dbContext;
            _desserts = dbContext.Desserts;
        }

        public IEnumerable<Dessert> GetAll()
        {
            return _desserts
                    .OrderBy(d => d.Naam)
                    .ToList();
        }

        public Dessert GetBy(int id)
        {
            return _desserts
                    .SingleOrDefault(d => d.Id == id);
        }

        public bool TryGetDessert(int id, out Dessert dessert)
        {
            dessert = _context.Desserts
                    .FirstOrDefault(d => d.Id == id);
            return dessert != null;
        }

        public void Add(Dessert dessert)
        {
            _desserts.Add(dessert);
        }

        public void Update(Dessert toUpdateDessert)
        {
            var dessert = _desserts.FirstOrDefault(d => d.Id == toUpdateDessert.Id);

            if (dessert != null)
            {
                _context.Update(dessert);
            }

            //_context.Update(toUpdateMenu);
        }

        public void Delete(Dessert dessert)
        {
            _desserts.Remove(dessert);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
