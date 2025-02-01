using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyInventory.Persistence.Abstract
{
    public interface IGenericDataAccess<T> where T : class
    {
        /// <summary>
        /// Retrieves entities with optional related data.
        /// </summary>
        /// <param name="includes">Expressions specifying related entities to include.</param>
        /// <returns>A collection of entities.</returns>
        Task<IEnumerable<T>> GetAsync(params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Retrieves all entities.
        /// </summary>
        /// <returns>A list of all entities.</returns>
        Task<List<T>> GetAsync();

        /// <summary>
        /// Retrieves a list of entities by their unique identifiers.
        /// </summary>
        /// <param name="idList"></param>
        /// <param name="idField"></param>
        /// <returns>The matching entity list</returns>
        Task<List<T>> GetAsync(List<int> idList, string idField);

        /// <summary>
        /// Retrieves a single entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <param name="idField">The name of the identifier field (optional).</param>
        /// <param name="includes">Expressions specifying related entities to include.</param>
        /// <returns>The matching entity.</returns>
        Task<T> GetAsync(int? id = null, string? idField = null, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Inserts a new entity into the database.
        /// </summary>
        /// <param name="item">The entity to insert.</param>
        Task InsertAsync(T item);

        /// <summary>
        /// Updates an existing entity in the database.
        /// </summary>
        /// <param name="item">The entity with updated values.</param>
        Task UpdateAsync(T item);

        /// <summary>
        /// Deletes an entity from the database.
        /// </summary>
        /// <param name="item">The entity to delete.</param>
        Task DeleteAsync(T item);

        /// <summary>
        /// Deletes multiple entities from the database.
        /// </summary>
        /// <param name="items">The list of existing entities</typeparam>
        Task BulkDeleteAsync(List<T> items);

    }
}
