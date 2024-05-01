using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DAL.GenericRepository.Interfaces
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
