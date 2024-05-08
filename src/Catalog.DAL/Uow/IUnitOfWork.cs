using Catalog.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DAL.Uow
{
    public interface IUnitOfWork
    {
        int Commit();
        Task<int> CommitAsync();
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}
