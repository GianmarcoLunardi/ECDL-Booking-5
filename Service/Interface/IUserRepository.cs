using Identity2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity2.Service.Interface
{
    public interface IUserRepository
    {
        


         Task<ApplicationUser> get(Guid id);
         Task<List<SelectListItem>> DownList_Rule_User(Guid IdUser);
        
        
    }
}
