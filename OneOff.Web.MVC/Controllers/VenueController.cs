﻿using System;
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

namespace OneOff.Web.MVC.Controllers
{
    public class VenueController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Venue
        public async Task<ActionResult> Index()
        {
            return View(await db.Gigs.ToListAsync());
        }

        // GET: Venue/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gig gig = await db.Gigs.FindAsync(id);
            if (gig == null)
            {
                return HttpNotFound();
            }
            return View(gig);
        }

        // GET: Venue/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Venue/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "GigId,OwnerId,Date,PostalCode")] Gig gig)
        {
            if (ModelState.IsValid)
            {
                db.Gigs.Add(gig);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(gig);
        }

        // GET: Venue/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gig gig = await db.Gigs.FindAsync(id);
            if (gig == null)
            {
                return HttpNotFound();
            }
            return View(gig);
        }

        // POST: Venue/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "GigId,OwnerId,Date,PostalCode")] Gig gig)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gig).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(gig);
        }

        // GET: Venue/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gig gig = await db.Gigs.FindAsync(id);
            if (gig == null)
            {
                return HttpNotFound();
            }
            return View(gig);
        }

        // POST: Venue/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Gig gig = await db.Gigs.FindAsync(id);
            db.Gigs.Remove(gig);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
