using Identity2.Models;
using Identity2.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Identity2.Service;

namespace Identity2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGenericRepository<Exam> _RepoExam;

        public HomeController(ILogger<HomeController> logger, IGenericRepository<Exam> repoExam)
        {
            _logger = logger;
            _RepoExam = repoExam;
        }

        public IActionResult Index()
        {

            return View( _RepoExam.All() );
        }

       
        public IActionResult IndexProtetto()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
