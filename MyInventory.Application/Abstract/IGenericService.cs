using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyInventory.Application.Abstract
{
    public interface IGenericService<TRead, TCreate, TUpdate> where TRead : class where TCreate : class where TUpdate : class
    {
        /// <summary>
        /// Deletes an existing record.
        /// </summary>
        /// <param name="model">The model representing the entity to be deleted.</param>
        Task Delete(TRead model);


        /// <summary>
        /// Deletes a list of records.
        /// </summary>
        /// <param name="modelList">The modelList representing the entities to be deleted </param>
        Task BulkDelete(List<TRead> modelList);

        /// <summary>
        /// Inserts a new record.
        /// </summary>
        /// <param name="model">The model representing the entity to be inserted.</param>
        /// <returns>The inserted entity.</returns>
        Task<TRead> Insert(TCreate model);

        /// <summary>
        /// Updates an existing record.
        /// </summary>
        /// <param name="model">The model containing the updated values.</param>
        Task Update(TUpdate model);

        /// <summary>
        /// Retrieves a record by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <returns>The entity matching the given identifier.</returns>
        Task<TRead> Get(int id);

        /// <summary>
        /// Retrieves list of records by their unique identifiers.
        /// </summary>
        /// <param name="idList">The list of unique identifiers.</param>
        /// <returns>The matching entity list.</returns></returns>
        Task<List<TRead>> Get(List<int> idList);

        /// <summary>
        /// Retrieves all records.
        /// </summary>
        /// <returns>A list of all entities.</returns>
        Task<List<TRead>> Get();
    }
}
