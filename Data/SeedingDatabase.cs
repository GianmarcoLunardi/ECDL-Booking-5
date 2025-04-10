using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using Identity2.Models;





namespace Identity2.Data
{
    public static class SeedingDatabase
    {

        public static void SeedStart(this IApplicationBuilder app)
        {
            SeedStore(app).GetAwaiter().GetResult();
        }
        private async static Task SeedStore(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                //IConfiguration config =
                //scope.ServiceProvider.GetService<IConfiguration>();
                UserManager<ApplicationUser> userManager =
                scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();

                RoleManager<IdentityRole> roleManager =
                scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                /*
                string roleName = config["Dashboard:Role"] ?? "Dashboard";


                string userName = config["Dashboard:User"] ?? "admin@example.com";
                string password = config["Dashboard:Password"] ?? "mysecret";
                */


                // Inserimento del ruolo Teacher
                if (await roleManager.FindByNameAsync("Teacher") == null)
                {
                    // inserisce il ruolo insegnabte
                    await roleManager.CreateAsync(new IdentityRole("Teacher"));

                }

                if (await roleManager.FindByNameAsync("Student") == null)
                {
                    // inserisce il ruolo insegnabte
                    await roleManager.CreateAsync(new IdentityRole("Student"));

                }



                ApplicationUser Utente = await userManager.FindByEmailAsync("gianmarco.lunardi@iis-bressanone.edu.it");
                if (Utente == null)
                {
                    Utente = new ApplicationUser
                    {
                        UserName = "Admin",
                        Email = "gianmarco.lunardi@iis-bressanone.edu.it",   // inserire una mail di configurazione
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(Utente);
                    Utente = await userManager.FindByEmailAsync("gianmarco.lunardi@iis-bressanone.edu.it");

                    await userManager.AddPasswordAsync(Utente, "admin");
                }
                if (!await userManager.IsInRoleAsync(Utente, "Teacher"))
                {
                    await userManager.AddToRoleAsync(Utente, "Teacher");
                }
            }


        }

    }
}
