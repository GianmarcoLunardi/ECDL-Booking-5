using Identity2.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// questa classe inizializza l utente 
// admin    admin
namespace Identity2.Properties
{
    public class InitiazileDB
    {
        ApplicationUser AmministratoreSitema = new ApplicationUser
        {
            UserName = "admin",
            Email = "gianmarcofi@gmail.com",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
        };




        IdentityRole RuoloStudente = new IdentityRole
        {
            Name = "Studente",
            NormalizedName = "STUDENTE"
        };

        IdentityRole RuoloInsegnante = new IdentityRole
        {
            Name = "Insegnante",
            NormalizedName = "INSEGNANTE"
        };






    }

}
