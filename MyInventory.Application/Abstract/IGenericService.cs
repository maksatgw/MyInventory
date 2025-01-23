using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInventory.Application.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task TDelete(T model);
        Task TInsert(T model);
        Task TUpdate(T model);
        Task<T> TGet(int id);
        Task<List<T>> TGet();
    }
}
