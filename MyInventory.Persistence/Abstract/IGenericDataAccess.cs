using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInventory.Persistence.Abstract
{
    public interface IGenericDataAccess<T> where T : class
    {
        public List<T> Get();
        T Get(int id);
        void Insert(T item);
        void Update(T item);
        void Delete(T item);
    }
}
