using Catalog.DAL.Data;
using Catalog.DAL.GenericRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DAL.GenericRepository.Base
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
