using Identity2.Data;
using Identity2.Models.Identity;
using Identity2.Service.Interface;
using Identity2.Service.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;

using System.Threading.Tasks;
using Identity2.ViewModel;

namespace Identity2.Controllers
{
    [Area("Admin")]
    public class SchoolController : Controller
    {


        private readonly IClassRepository _classRepository;
        private readonly ISchoolRepository _schoolRepository;


        public SchoolController(
            IClassRepository classRepository,
            ISchoolRepository schoolRepository
            )
        {
            _classRepository = classRepository;
            _schoolRepository = schoolRepository;
        }



        // GET: SchoolController
        // collezione delle scuole
        public async Task<ActionResult> Index()
        {
            var x = await _schoolRepository.All();
            return View(x);
        }
       
        [HttpGet]
        public async Task<ActionResult> IndexClass(Guid id) {
            /*
                  IEnumerable<School> lista = await RepoSchool.All();
                  //return View();
                  //return Ok();
                  //return Ok();
                  lista = lista.Where(x => x.id == Guid.Parse(id_school)).ToList();
                  return View(lista);*/

            // Data.leggere l inner joinn
            School x = await _schoolRepository.Find(id);
                return View(x);
        }
    
        // GET: SchoolController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SchoolController/Create
        public ActionResult Create()
        {
            School s = new School();
            return View(s);
        }

        // POST: SchoolController/Create
        [HttpPost]
       //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create_Scool(School collection)
        {
            await _schoolRepository.Add(collection);
            return RedirectToAction(nameof(Index));
            

           
        }

        // Crea le classi di una scuola


        // GET: SchoolController/Create
       // pagina che visualizza le classi di una determinata scuola
        /*
        public async Task<ActionResult> IndexClass3( Guid id)
        {
            Guid x = id;
            return View(await repoSchool.Find(id));
        }
        */
        [HttpGet("AddClass/{id:Guid}")]
        public async Task<ActionResult> AddClass(Guid id)
        {
            CreateClassSchool x = new CreateClassSchool();
            x.Id_School = id;

            return View(x);
        }


        [HttpPost]
        public async Task<ActionResult> AddClass_Post(CreateClassSchool x)
        {
            //CreateClassSchool x = new CreateClassSchool();
            //x.Id_Classe = id;

            Class classe = new Class();
            classe.Name = x.Classe;
            //classe.School = await _classRepository.Find(x.Id_School);
            classe.SchoolId = x.Id_School;



                    //classe.School.Add(await RepoSchool.Find(x.Id_School));
                    //classe.SchoolId = x.Id_School;
                    //classe.School.Add(await RepoSchool.Find(x.Id_School));

                    

                    await _classRepository.Add(classe);
            // Add Repo School

            //School scuola = await RepoSchool.Find(x.Id_School);
           // scuola.Classes.Add(classe);

            //await RepoSchool.Add(scuola);

            //School x2 = await RepoSchool.Find(x.Id_Classe);
            //x2.Classes.Add(classe);

            //await RepoSchool.Edit(x2);
            //return RedirectToAction("IndexClass", x.Id_School);
            return RedirectToAction("IndexClass", new { id = x.Id_School } );
            //return View(x);
        }

        // POST: SchoolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_Classx(IFormCollection collection)
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

        // GET: SchoolController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SchoolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: SchoolController/Delete/5
       
        public ActionResult Delete(Guid id)
        {
            //RepoSchool.Delete(id);
            return RedirectToAction("Index");
        }




        // POST: SchoolController/Delete/5
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
