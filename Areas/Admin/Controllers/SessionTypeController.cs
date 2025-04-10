using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity2.Models;
using Identity2.Service;
using Identity2.Service.Interface;



namespace Identity2.Controllers
{
    public class SessionTypeController : Controller { 


        private readonly IGenericRepository<SessionType> SessionRepo;

        public  SessionTypeController(IGenericRepository<SessionType> sessionRepo)
        {
            SessionRepo = sessionRepo;
        }

        // GET: SessionTypeController
        public async Task<ActionResult> Index()
        {
            
            return View( await SessionRepo.All());
        }

        // GET: SessionTypeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SessionTypeController/Create
        public ActionResult Create()
        {
            SessionType t = new SessionType();
            return View(t);
        }

        // POST: SessionTypeController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async  Task<ActionResult> Create(SessionType Enity)
        {
            await SessionRepo.Add(Enity);
            return RedirectToAction(nameof(Index));


            /*

            try
            {   
                await SessionRepo.Add(Enity);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            */
        }

        // GET: SessionTypeController/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            SessionType x = await SessionRepo.Find(id);
            return View(x);
        }

        // POST: SessionTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRecord(SessionType Entity)
        {
                SessionRepo.Edit(Entity);
                return RedirectToAction(nameof(Index));

        }

        // GET: SessionTypeController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(Guid id)
        {
            await SessionRepo.Delete(id);
            return RedirectToAction("Index");
           // return View( typeof(Index));
        }

        // POST: SessionTypeController/Delete/5
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
