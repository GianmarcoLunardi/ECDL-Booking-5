using Identity2.Models.Identity;
using Identity2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity2.Service.Interface
{
    public interface IClassRepository
    {
        Task Add(Class entity); //ok
        Task Delete(Guid id); //ok
        Task<Class> FindInclude(Guid id, string Inclu = null);
        Task<Class> Find(Guid id);
        Task<IEnumerable<Class>> All(PageInfo page = null); //ok
    }
}
