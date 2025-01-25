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

        public async Task<List<T>> Get()
        {
            return await _appDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            return await _appDbContext.Set<T>().FindAsync(id);
        }

        public async Task Insert(T item)
        {
            await _appDbContext.AddAsync(item);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Update(T item)
        {
            _appDbContext.Update(item);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task Delete(T item)
        {
            _appDbContext.Remove(item);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> Get(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _appDbContext.Set<T>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }
    }
}
