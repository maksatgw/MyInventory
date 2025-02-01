using MyInventory.Application.DTO;
using MyInventory.Application.DTO.EquipmentDtos;
using MyInventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInventory.Application.Abstract
{
    public interface IEquipmentService : IGenericService<EquipmentDto, CreateEquipmetDto, UpdateEquipmentDto>
    {
        /// <summary>
        /// Retrieves a paginated, filtered, and searchable list of equipment asynchronously.
        /// </summary>
        /// <param name="pageNumber">The page number to retrieve (1-based index).</param>
        /// <param name="pageSize">The number of equipment items per page.</param>
        /// <param name="categoryId">Optional. Filters the equipment by the specified category ID.</param>
        /// <param name="locationId">Optional. Filters the equipment by the specified location ID.</param>
        /// <param name="searchQuery">
        /// Optional. Searches for equipment where the name or description contains the given query (case-insensitive).
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation that contains a <see cref="PagedDto{EquipmentDto}"/>:
        /// - A list of equipment DTOs for the specified page that match the filters and search criteria.
        /// - The total number of equipment items that match the given filters and search criteria.
        /// - Pagination metadata.
        /// </returns>
        Task<PagedDto<EquipmentDto>> GetPagedEquipments(int pageNumber, int pageSize, int? categoryId = null, int? locationId = null, string? searchQuery = null);
    }
}
