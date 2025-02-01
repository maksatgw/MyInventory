using MyInventory.Domain.Entities;
using MyInventory.Persistence.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInventory.Persistence.Entity.Abstract
{
    public interface IEquipmentDataAccess : IGenericDataAccess<Equipment>
    {
        /// <summary>
        /// Retrieves a paginated, filtered, and searchable list of equipment asynchronously.
        /// </summary>
        /// <param name="pageNumber">The page number to retrieve (1-based index).</param>
        /// <param name="pageSize">The number of equipment items per page.</param>
        /// <param name="categoryId">Optional. Filters the equipment by the specified category ID.</param>
        /// <param name="searchQuery">
        /// Optional. Searches for equipment where the name or description contains the given query.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation that contains:
        /// - A list of equipment for the specified page that matches the filters and search criteria.
        /// - The total number of equipment items that match the given filters and search criteria.
        /// </returns>
        Task<(List<Equipment>, int)> GetPagedEquipmentsAsync(int pageNumber, int pageSize, int? categoryId = null, int? locationId = null, string? searchQuery = null);
    }
}
