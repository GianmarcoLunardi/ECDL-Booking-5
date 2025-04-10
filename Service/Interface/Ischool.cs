using Identity2.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity2.Service.Interface
{
    interface Ischool : IGenericRepository<School>
    {
        Task Find_Class(Guid id);
    }
}
