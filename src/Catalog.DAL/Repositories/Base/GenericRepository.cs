using Catalog.DAL.Data;
using Catalog.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DAL.Re.Base
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private CatalogDbContext _context = null;
        private DbSet<TEntity> _dbSet = null;

        public GenericRepository(CatalogDbContext context)
        {
           _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>,IOrderedQueryable<TEntity>> orderBy=null,
            int? page = null, int? pageSize = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet.Where(predicate);

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, includeProperties) => current.Include(includeProperties));
            }

            if (page != null && pageSize != null)
            {
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }
            return await query.ToListAsync();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void HardDelete(TEntity entity)
        {
           _dbSet.Remove(entity);
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public async Task InsertAsync(TEntity entity)
        {
           await _dbSet.AddAsync(entity);
        }

        public void SoftDelete(TEntity entity)
        {
            entity.GetType().GetProperty("IsDeleted")?.SetValue(entity, true);
            _dbSet.Update(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

    }
}
