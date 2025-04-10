using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Identity2.Areas.Identity.Data;
using Identity2.Models;
using Identity2.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoMapper;


namespace Identity2.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;
        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        
        public InputModel InputVecchio { get; set; }

        [BindProperty]
        public InputViewModel_Manage_index Input { get; set; }



        //Rimosso Dichiarazione dell oggetto e poi 
        //spoatato dentro la cartella Identity/data
        // l oggetto è da togliere

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }


            // Inserimento Nuovi Campi




            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
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

            //[Display(Name = "Scuole")]
            //public List<SelectListItem> ListSchool { get; set; } = null;

            public School School { get; set; }
            // Fine inseriemnto dei nuovi ccampi





        }

        private async Task LoadAsync(ApplicationUser user)
        {





            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = _mapper.Map<InputViewModel_Manage_index>(user);

            /*
            Input = new InputModel
            {
                
                PhoneNumber = phoneNumber,
                Name = user.Name,
                Surname = user.Surname,
                Born = user.Born,
                Address = user.Address,
                City = user.City,
                Country = user.Country,
                familyContactPerson = user.familyContactPerson,
                familyContactPerson_phone = user.familyContactPerson,


            };
            */

        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {

                ApplicationUser utente = _mapper.Map<ApplicationUser>(Input);
                _userManager.UpdateAsync(utente);

                await LoadAsync(user);

                

                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
