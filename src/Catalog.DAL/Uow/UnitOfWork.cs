using Catalog.DAL.Data;
using Catalog.DAL.Re.Base;
using Catalog.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DAL.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private CatalogDbContext _context;
        private Dictionary<Type,object> _repositories;

        public UnitOfWork(CatalogDbContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type,object>();
        }
        public int Commit()
        {
           return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync(CancellationToken.None);
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
           if (_repositories.ContainsKey(typeof(TEntity)))
            {
                return (IGenericRepository<TEntity>)_repositories[typeof(TEntity)];
            }

            var repository = new GenericRepository<TEntity>(_context);
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(obj: this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
