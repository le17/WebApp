using EFCore.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repo
{
    public interface IEFCoreRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangAsync();

        Task<Heroi[]> GetAllHerois(bool incluirBatalha = false);
        Task<Heroi> GetHeroisById(int id, bool incluirBatalha = false);
        Task<Heroi[]> GetHeroisBynome(string nome, bool incluirBatalha = false);

        Task<Batalha[]> GetAllBatalhas(bool incluirBatalha = false);
        Task<Batalha> GetBatalhaById(int id, bool incluirBatalha = false);
    }
}
