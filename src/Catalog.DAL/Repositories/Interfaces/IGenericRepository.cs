using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DAL.Repositories.Interfaces
{
    /// <summary>
    /// This interface implemented base database operation with generic repository pattern
    /// </summary>
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Retrieves all entities of type <typeparamref name="TEntity"/>
        /// </summary>
        /// <returns>
        /// An enumerable collection of all entities of type <typeparamref name="TEntity"/>
        /// </returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Retrieves all entities async of type <typeparamref name="TEntity"/>
        /// </summary>
        /// <returns>
        /// An enumerable collection of all entities of type <typeparamref name="TEntity"/>
        /// </returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Retrieves entity by id of type <typeparamref name="TEntity"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Returns an entity of type <typeparamref name="TEntity"/>
        /// </returns>
        TEntity GetById(object id);

        /// <summary>
        /// Retrieves entity by id async of type <typeparamref name="TEntity"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Returns an entity of type <typeparamref name="TEntity"/>
        /// </returns>
        Task<TEntity> GetByIdAsync(object id);

        /// <summary>
        /// Asynchronously retrieves entities of type <typeparamref name="TEntity"/> based on the specified filter expression and optional ordering, pagination, and eager loading of related entities.
        /// </summary>
        /// <param name="predicate">The filter expression used to filter entities.</param>
        /// <param name="orderBy">An optional function to order the retrieved entities.</param>
        /// <param name="page">An optional page number for pagination.</param>
        /// <param name="pageSize">An optional page size for pagination.</param>
        /// <param name="includes">Optional expressions specifying related entities to be eagerly loaded.</param>
        /// <returns>A task representing the asynchronous operation, returning an enumerable collection of entities satisfying the filter expression.</returns>
        public Task<IEnumerable<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? page = null, int? pageSize = null, params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        /// Inserts the specified entity of type <typeparamref name="TEntity"/>
        /// </summary>
        /// <param name="entity"></param>
        void Insert(TEntity entity);

        /// <summary>
        /// Inserts the specified entity of type <typeparamref name="TEntity"/>
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task InsertAsync(TEntity entity);

        /// <summary>
        /// Updates the specified entity of type <typeparamref name="TEntity"/>.
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// Soft delete with using IsDeleted flag for entity.
        /// </summary>
        /// <param name="entity"></param>
        void SoftDelete(TEntity entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity"></param>
        void HardDelete(TEntity entity);
    }
}
