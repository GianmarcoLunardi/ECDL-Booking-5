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
    public class ExamController : Controller
    {
        private readonly IGenericRepository<Exam> ExamRepo;
        private readonly IGenericRepository<SessionType> SessionRepo;

        public ExamController(IGenericRepository<Exam> examRepo, IGenericRepository<SessionType> sessionRepo)
        {
            ExamRepo = examRepo;
            SessionRepo = sessionRepo;
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

            CreateSelectionView x = new CreateSelectionView();

            x.exam = new Exam();
            x.exam.Date = DateTime.Now;
            x.sessionList =  await SessionRepo.All();

            return View(x);
        }

        // GET: ControllerController/Create
        [HttpPost]
        async public Task<ActionResult>Create_Post(ViewModel.CreateSelectionView x)
        {
            Exam e = new Exam();
            e = x.exam;
            e.SessionType = await SessionRepo.Find(x.sessionId.ToString());
            await ExamRepo.Add(e);

            // return Redirect("/home");
            return Redirect("/home");
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
