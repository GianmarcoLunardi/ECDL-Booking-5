using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity2.Models;
using Identity2.ViewModel;

namespace Identity2.Service.Interface
{
    public interface IExamRepository
    {
        Task Add(Exam entity); //ok
        Task Add(Exam entity, Guid IdSchool); //ok
        Task Delete(Guid id); //ok
        //Task<Exam> FindInclude(Guid id, string Inclu = null);
        Task<Exam> Find(Guid id);
        Task<IEnumerable<Exam>> All(PageInfo page = null); //ok
        Task<IEnumerable<Exam>> All_School(PageInfo page = null);
        //Task<List<SelectListItem>> ListSchoolSelect();
    }
}
