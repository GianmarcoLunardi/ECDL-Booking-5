using Identity2.Models.Identity;
using Identity2.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity2.Service.Interface
{
    public interface ISchoolRepository {

        Task Add(School entity); //ok
        Task Delete(Guid id); //ok
        Task<School> FindInclude(Guid id, string Inclu = null);
        Task<School> Find(Guid id);
        Task<IEnumerable<School>> All( PageInfo page=null); //ok
        Task<List<SelectListItem>> ListSchoolSelect(Guid? id);
    }
}
