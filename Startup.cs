using Identity2.Data;
using Identity2.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity2.Service.Interface;
using Identity2.Service.Repository;
using Identity2.Service;
using Identity2.Models.Identity;

using Identity2.Data;
using AutoMapper;
using Identity2.Profiles;

namespace Identity2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.SignIn.RequireConfirmedAccount = false;
            }
            )
            //
            .AddRoles<IdentityRole>()
            .AddRoleManager<RoleManager<IdentityRole>>()
            //DI applicazion user
             .AddUserManager<UserManager<ApplicationUser>>()
            .AddSignInManager<SignInManager<ApplicationUser>>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultUI()
            
            // Add Token
            //.AddDefaultTokenProviders();
            // Di Servizio login    
           ; // utilizzo del context

            ///  Configurazione dle contex dei prodotti
           
            
            services.AddDbContext<ContextDati>(opts => {
                opts.UseSqlServer(
                Configuration.GetConnectionString("DatiConnection"));
            });

            // Configurazione di automapper
            services.AddAutoMapper(typeof(Profiles.MapperModel));

            // Servizi
            services.AddTransient<IGenericRepository<SessionType>, GenericRepository<SessionType>>();
            //services.AddTransient<IGenericRepository<Exam>, GenericRepository<Exam>>();
            services.AddTransient<IGenericRepository<Place>, GenericRepository<Place>>();
           // services.AddTransient<IGenericRepository<School>, IdentityRepository<School>>();
            //services.AddTransient<IGenericRepository<Class>, IdentityRepository<Class>>();

            //servizi 2
            services.AddTransient<ISchoolRepository, SchoolRepository>();
            services.AddTransient<IClassRepository, ClassRepository>();
            services.AddTransient<IExamRepository, ExamRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            
            //IClassRepository

            //compilazione delle pagine razdor a runtime
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "area",
                pattern: "{area=User}/{controller=Home}/{action=Index}/{id?}");


                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });

            /// configurazione del seeding
            app.SeedStart();
            //ApplicationDbContext.CreateAdminAccount(app.ApplicationServices).Wait();

         

        }
    }
}

//