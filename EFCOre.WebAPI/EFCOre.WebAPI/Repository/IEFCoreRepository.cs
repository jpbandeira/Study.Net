using EFCOre.WebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCOre.WebAPI.Repository
{
    interface IEFCoreRepository
    {
        void Add<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangeAsync();

        Task<Heroi[]> GetAll();

        Task<Heroi> GetHeroiById(int id);

        Task<Heroi> GetHeroiByName(string nome);
    }
}
