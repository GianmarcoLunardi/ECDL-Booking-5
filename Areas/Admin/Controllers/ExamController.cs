using Identity2.Models;
using Identity2.ViewModel;
using Identity2.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity2.Controllers
{
    [Area("Admin")]
    public class ExamController : Controller
    {
        private readonly IExamRepository ExamRepo;
        private readonly IGenericRepository<SessionType> SessionRepo;
        private readonly ISchoolRepository _SchoolRepository;


        public ExamController(IExamRepository examRepo, 
            IGenericRepository<SessionType> sessionRepo,
            ISchoolRepository SchoolRepository
            )
        {
            ExamRepo = examRepo;
            SessionRepo = sessionRepo;
            _SchoolRepository = SchoolRepository;
        }

        // GET: ControllerController
        public async Task<ActionResult> Index()
        {
            return View(await ExamRepo.All());
        }

        // GET: ControllerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ControllerController/Create
        async public Task<ActionResult> Create()
        {

            //CreateSelectionView x = new CreateSelectionView();
            AdminExamCreate x = new AdminExamCreate();



            x.exam = new Exam();
            x.exam.Date = DateTime.Now;
            x.sessionList =  await SessionRepo.All();
            x.PlaceList =await _SchoolRepository.ListSchoolSelect(null);
            x.PlaceSelected = null;            
            return View(new Admin_Exam_Create() );
        }

        // GET: ControllerController/Create
        [HttpPost]
        async public Task<ActionResult>Create_Post(AdminExamCreate x)
        {
            //Exam e = new Exam();
            //e = x.exam;
            //.SessionType = await SessionRepo.Find(x.sessionId.ToString());
            //await ExamRepo.Add(x.exam,x.PlaceSelected);
            //prova uno
            //await ExamRepo.Add(x.exam);
            //Prova Due
            await ExamRepo.Add(x.exam, x.exam.IdSchool);

            // return Redirect("/home");
            return Redirect("/User/home/index");
        }


        // POST: ControllerController/Create
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

        // GET: ControllerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ControllerController/Edit/5
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

        // GET: ControllerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ControllerController/Delete/5
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
