using EFCOre.WebAPI.Data;
using EFCOre.WebAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCOre.WebAPI.Repository
{
    public class EFCoreRepository : IEFCoreRepository
    {
        
        public readonly HeroiContext _context;
        public EFCoreRepository(HeroiContext heroiContext)
        {
            _context = heroiContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Heroi[]> GetAll()
        {
            IQueryable<Heroi> query = _context.Herois.AsNoTracking().Include(batalha => batalha.Batalha);

            return await query.ToArrayAsync();
        }

        public Task<Heroi> GetHeroiById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Heroi> GetHeroiByName(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
