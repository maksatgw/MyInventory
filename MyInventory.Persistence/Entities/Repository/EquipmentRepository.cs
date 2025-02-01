using Microsoft.EntityFrameworkCore;
using MyInventory.Domain.Entities;
using MyInventory.Persistence.Context;
using MyInventory.Persistence.Entity.Abstract;
using MyInventory.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInventory.Persistence.Entities.Repository
{
    public class EquipmentRepository : GenericRepository<Equipment>, IEquipmentDataAccess
    {
        private readonly MyInventoryDbContext _appDbContext;
        public EquipmentRepository(MyInventoryDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<(List<Equipment>, int)> GetPagedEquipmentsAsync(int pageNumber, int pageSize, int? categoryId = null, int? locationId = null, string? searchQuery = null)
        {
            var query = _appDbContext.Equipments.AsQueryable();

            if (categoryId.HasValue)
            {
                query = query.Where(e => e.CategoryId == categoryId.Value);
            }

            if (locationId.HasValue)
            {
                query = query.Where(e => e.LocationId == locationId.Value);
            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery.ToLower();
                query = query.Where(e => e.Brand.ToLower().Contains(searchQuery) || e.Description.ToLower().Contains(searchQuery) || e.SerialNumber.ToLower().Contains(searchQuery) || e.Model.ToLower().Contains(searchQuery));
            }

            int totalItems = await query.CountAsync();
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Include(x => x.EquipmentImages)
                .ToListAsync();

            return (items, totalItems);
        }
    }
}
