using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarWars.Core.Data
{
    public interface IRepository<TEntity, Tkey>
        where TEntity : class
    {
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> GetAll(string include);
        Task<List<TEntity>> GetAll(IEnumerable<string> includes);

        Task<TEntity> Get(Tkey id);
        Task<TEntity> Get(Tkey id, string include);
        Task<TEntity> Get(Tkey id, IEnumerable<string> includes);

        TEntity Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Delete(Tkey id);
        void Update(TEntity entity);
        Task<bool> SaveChangesAsync();
    }
}
