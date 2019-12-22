using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StarWars.Core.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Data.EntityFramework.Repositories
{
    public abstract class EfRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
    {
        protected DbContext _db;
        protected DbSet<TEntity> _dbSet;
        protected readonly ILogger _logger;

        protected EfRepository() { }

        protected EfRepository(DbContext db, ILogger logger)
        {
            _db = db;
            _dbSet = db.Set<TEntity>();
            _logger = logger;
        }

        public virtual Task<List<TEntity>> GetAll()
        {
            _logger.LogInformation("Get all {type}s", typeof(TEntity).Name);
            return _dbSet.ToListAsync();
        }

        public Task<List<TEntity>> GetAll(string include)
        {
            _logger.LogInformation("Get all {type}s (including {include})", typeof(TEntity).Name, include);
            return _dbSet.Include(include).ToListAsync();
        }

        public Task<List<TEntity>> GetAll(IEnumerable<string> includes)
        {
            _logger.LogInformation("Get all {type}s (including [{includes}])", typeof(TEntity).Name, string.Join(",", includes));
            var query = _dbSet.AsQueryable();
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query.ToListAsync();
        }

        public virtual Task<TEntity> Get(TKey id)
        {
            _logger.LogInformation("Get {type} with id = {id}", typeof(TEntity).Name, id);
            return _dbSet.SingleOrDefaultAsync(c => c.Id.Equals(id));
        }

        public Task<TEntity> Get(TKey id, string include)
        {
            _logger.LogInformation("Get {type} with id = {id} (including {include})", typeof(TEntity).Name, id, include);
            return _dbSet.Include(include).SingleOrDefaultAsync(c => c.Id.Equals(id));
        }

        public Task<TEntity> Get(TKey id, IEnumerable<string> includes)
        {
            _logger.LogInformation("Get {type} with id = {id} (including [{include}])", typeof(TEntity).Name, id, string.Join(",", includes));
            var query = _dbSet.AsQueryable();
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query.SingleOrDefaultAsync(c => c.Id.Equals(id));
        }

        public virtual TEntity Add(TEntity entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public virtual void Delete(TKey id)
        {
            var entity = new TEntity { Id = id };
            _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }

        public virtual async Task<bool> SaveChangesAsync()
        {
            return (await _db.SaveChangesAsync()) > 0;
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }
    }
}
