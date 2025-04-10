using AutoMapper;
using Identity2.Data;
using Identity2.Models;
using Identity2.Service.Interface;
using Identity2.ViewModel;

using Identity2.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity2.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        //private readonly IdentityRole _identityRole;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _SignInManager;
        private readonly ApplicationDbContext _Context;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ISchoolRepository _SchoolRepo;


        public UsersController( RoleManager<IdentityRole> roleManager, 
                                UserManager<ApplicationUser> userManager, 
                                SignInManager<ApplicationUser> signInManager, 
                                ApplicationDbContext context,
                                IMapper mapper, 
                                IUserRepository userRepository,
                                ISchoolRepository SchoolRepo)
        {
            //_identityRole = identityRole;
            _roleManager = roleManager;
            _userManager = userManager;
            _SignInManager = signInManager;
            _Context = context;
            _mapper = mapper;
            _userRepository = userRepository;
            _SchoolRepo = SchoolRepo;
        }

        // GET: UsersController

        // visualizzs gòi utenti
        public ActionResult Index()
        {
            DbSet<ApplicationUser> Tabella; 
            return View(_userManager.Users);
        }

        // GET: UsersController/Details/5
        [HttpGet("Guid:id")]
        public async Task<ActionResult> User(Guid id)
        {
            ApplicationUser utente = await _userRepository.get(id);
            Admin_Users_User UteneteView = _mapper.Map<Admin_Users_User>(utente);
            UteneteView.ListSchool = await _SchoolRepo.ListSchoolSelect(null);
            return View(UteneteView) ;

            //return View(null);
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        /*
        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        */
        // POST: UsersController/Edit/5
        
        //[ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Edit( Admin_Users_User utenteDto)
        {


            // vienne ricevuto l oggetto utente da forma
            // si controlla la sua validità
            // nel caso l oggetto è valido lo si elabora


            //var result = await _userManager.UpdateAsync(utente);
            if (ModelState.IsValid)
            {
                ApplicationUser utente = _mapper.Map<ApplicationUser>(utenteDto);
                // di modifica quell utente li 
                return RedirectToAction(nameof(Index));
            }
            else   
                {
                // caso in cui un oggetto non passa il controllo 
                // ritorna al form precedente
                return View();
                }


        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
