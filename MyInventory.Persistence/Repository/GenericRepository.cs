using MyInventory.Persistence.Abstract;
using MyInventory.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<T> Get()
        {
            return _appDbContext.Set<T>().ToList();
        }

        public T Get(int id)
        {
            return _appDbContext.Set<T>().Find(id);
        }

        public void Insert(T item)
        {
            _appDbContext.Add(item);
            _appDbContext.SaveChanges();
        }

        public void Update(T item)
        {
            _appDbContext.Update(item);
            _appDbContext.SaveChanges();
        }
        public void Delete(T item)
        {
            _appDbContext.Remove(item);
            _appDbContext.SaveChanges();
        }
    }
}
}
