using AutoMapper;
using Identity2.Data;
using Identity2.Models;
using Identity2.Service.Interface;
using Identity2.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity2.Service.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext UserDatabase;
        //private readonly UserManager<IdentityUser> _UtenteManager;

        private readonly RoleManager<IdentityRole> _RoleManager;

        public UserRepository(ApplicationDbContext userDatabase
             //, UserManager<IdentityUser> UtenteManager
             , RoleManager<IdentityRole> RoleManager


            )
        {
            //_UtenteManager = UtenteManager;
            UserDatabase = userDatabase;
            _RoleManager = RoleManager ;
        }


        // Implementazione del menu  a tendina
        async Task<List<SelectListItem>> IUserRepository.DownList_Rule_User(Guid IdUser)
        {
            
            List<SelectListItem> Lista = new List<SelectListItem>();

            foreach ( var x in _RoleManager.Roles)
            {

                Lista.Add(
                    new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id,
                        Selected = false
                    }
                );
            }

            return Lista;
            //throw new NotImplementedException();
        }

        async Task<ApplicationUser> IUserRepository.get(Guid id)
        {
            // ricerca conn la api 
            // GetUserIdAsync

            ApplicationUser utente = await UserDatabase.ApplicationUsers.FindAsync(id.ToString());
            return utente;
            //UserManager
            //throw new NotImplementedException();
        }

    }
}
