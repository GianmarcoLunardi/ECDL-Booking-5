using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Identity2.Models;

namespace Identity2.Areas.Identity.Pages.Admin
{
    public class IndexModel : PageModel
    {
        public IndexModel(UserManager<ApplicationUser> userManager, ApplicationUser identityUser)
        {
            UserManager = userManager;
            IdentityUser = identityUser;
        }

        public UserManager<ApplicationUser> UserManager { get; set; }
        public ApplicationUser IdentityUser { get; set; }





        public void OnGet()
        {
        }
    }
}
