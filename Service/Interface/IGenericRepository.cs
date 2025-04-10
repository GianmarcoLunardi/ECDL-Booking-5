using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity2.Service.Interface
{

    public interface IGenericRepository<T> where T : class {
        Task Add(T entity);
        Task Delete(Guid id);
        Task<T> Find(string id);
        Task<T> FindInclude(Guid id, string Inclu = null);
        Task<T> Find(Guid id);
        Task<IEnumerable<T>> All();
        Task Edit(T entity);
    }

}
