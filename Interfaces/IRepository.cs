using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IRepository<T>
    {
        T Get(Guid id);
        IEnumerable<T> GetAll();

        void Add(T entity);

        void Modify(T entity);

        void Delete(T entity);
    }
}
