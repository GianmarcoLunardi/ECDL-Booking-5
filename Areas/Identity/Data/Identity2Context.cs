using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity2.Data
{
    public class Identity2Context : IdentityDbContext<ApplicationUser>
    {
        public Identity2Context(DbContextOptions<Identity2Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
