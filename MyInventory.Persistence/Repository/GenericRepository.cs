using Microsoft.EntityFrameworkCore;
using MyInventory.Persistence.Abstract;
using MyInventory.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyInventory.Persistence.Repository
{
    public class GenericRepository<T> : IGenericDataAccess<T> where T : class
    {
        private readonly MyInventoryDbContext _appDbContext;

        public GenericRepository(MyInventoryDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<T>> GetAsync()
        {
            return await _appDbContext.Set<T>().ToListAsync();
        }
        public async Task<List<T>> GetAsync(List<int> idList, string idField)
        {
            return await _appDbContext.Set<T>().Where(e => idList.Contains((int)EF.Property<int>(e, idField))).AsNoTracking().ToListAsync();
        }

        public async Task<T> GetAsync(int? id = null, string? idField = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _appDbContext.Set<T>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            if (id != null && idField != null)
            {
                query = query.Where(e => EF.Property<int>(e, idField) == id.Value);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task InsertAsync(T item)
        {
            await _appDbContext.AddAsync(item);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T item)
        {
            _appDbContext.Update(item);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(T item)
        {
            _appDbContext.RemoveRange(item);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _appDbContext.Set<T>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        public async Task BulkDeleteAsync(List<T> items)
        {
            _appDbContext.RemoveRange(items);
            await _appDbContext.SaveChangesAsync();
        }

       
    }
}
