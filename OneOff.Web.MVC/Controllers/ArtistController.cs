using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OneOff.Data.Entities;
using OneOff.Web.MVC.Models;
using OneOff.Services;
using Microsoft.AspNet.Identity;
using OneOff.Models;

namespace OneOff.Web.MVC.Controllers
{
    public class ArtistController : Controller
    {
        // GET: Artist
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GigService(userId);
            var model = service.GetGigsByUser();
            return View(model);
        }

        // GET: Artist/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var service = CreateGigService();
            var model = await service.GetGigByIdAsync(id);

            return View(model);
        }

        // GET: Artist/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artist/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(GigViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateGigService();
            
            if(await service.CreateGigAsync(model, true))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Note could not be created.");
            return View(model);
        }

        // GET: Artist/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var service = CreateGigService();
            var model = await service.GetGigByIdAsync(id);

            return View(model);
        }

        // POST: Artist/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, GigViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateGigService();

            if (await service.UpdateGigAsync(id, model))
            {
                TempData["SaveResult"] = "Your gig was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your gig could not be updated.");
            return View(model);
        }

        // GET: Artist/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var service = CreateGigService();
            var model = await service.GetGigByIdAsync(id);

            return View(model);
        }

        // POST: Artist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var service = CreateGigService();
            await service.DeleteGigAsync(id);

            TempData["SaveResult"] = "Your gig was cancelled";

            return RedirectToAction("Index");
        }

        private GigService CreateGigService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GigService(userId);
            return service;
        }
    }
}
