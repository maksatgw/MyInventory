using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInventory.Persistence.Abstract
{
    public interface IGenericDataAccess<T> where T : class
    {
        Task<List<T>> Get();
        Task<T> Get(int id);
        Task Insert(T item);
        Task Update(T item);
        Task Delete(T item);
    }
}
