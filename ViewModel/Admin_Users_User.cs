﻿using Identity2.Models.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace Identity2.ViewModel
{
    public class Admin_Users_User
    {

        [Key]
            [Display(Name = "Codice Identificativo")]
            public string Id { get; set; }

            [Required(ErrorMessage = "Inserire nome Utente")]
            [Display(Name = "Nome Utente")]
            public string UserName { get; set; }
        

            [Required(ErrorMessage = "Inserire una mail")]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Key]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }


            // Numero Di telefono implementato da me in quanto
            // non impementato dalllo scaffolden
            //            [Required]
            [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            [DataType(DataType.PhoneNumber)]
            [Display(Name = "Numero Di Telefono")]
            public string PhoneNumber { get; set; }



            // Inizio dell utente 
            //[Required]
            [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            [DataType(DataType.Text)]
            [Display(Name = "Nome")]
            public string Name { get; set; }

            //[Required]
            [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            [DataType(DataType.Text)]
            [Display(Name = "Cognome")]
            public string Surname { get; set; }

            //            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Data di Nascita")]
            public DateTime Born { get; set; }

            //            [Required]
            [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            [DataType(DataType.Text)]
            [Display(Name = "Indirizzo")]
            public string Address { get; set; }

            //            [Required]
            [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            [DataType(DataType.Text)]
            [Display(Name = "Città")]
            public string City { get; set; }

            //            [Required]
            [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            [DataType(DataType.Text)]
            [Display(Name = "Paese")]
            public string Country { get; set; }

            //            [Required]
            [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            [DataType(DataType.Text)]
            [Display(Name = "Nome Genitori")]
            public string familyContactPerson { get; set; }

            //            [Required]
            [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            [DataType(DataType.PhoneNumber)]
            [Display(Name = "Genitore-Tel")]
            public string familyContactPerson_phone { get; set; }

            //            [Required]
            [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            [DataType(DataType.EmailAddress)]
            [Display(Name = "Genitore-Mail")]
            public string familyContactPerson_email { get; set; }

        /// Iserito in quanto non considerato nell implementazione
        /// dell utente user standard


        // Relativo all id della scuola
        [Display(Name = "Scuola")]
        public Guid IdSchool { get; set; }

        public List<SelectListItem> ListSchool { get; set; } = null;
        [Display(Name = "Scuole")]
        public School School { get; set; }

        // Ruolo dell utente

        // Relativo all id della scuola
        [Display(Name = "Ruolo")]
        public Guid IdRuolo { get; set; }

        /*
        [Display(Name = "Ruolo")]
        public List<SelectListItem> ListSchool { get; set; } = null;
        [Display(Name = "Scuole")]
        public School School { get; set; }
        */




    }
}
