using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entities.Models;

namespace Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DificultiesController : Controller
    {
        private RecipesDataContext db = new RecipesDataContext();

        // GET: Dificulties
        public ActionResult Index()
        {
            return View(db.Dificulties.ToList());
        }

        // GET: Dificulties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dificulty dificulty = db.Dificulties.Find(id);
            if (dificulty == null)
            {
                return HttpNotFound();
            }
            return View(dificulty);
        }

        // GET: Dificulties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dificulties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DificultyId,Name")] Dificulty dificulty)
        {
            if (ModelState.IsValid)
            {
                db.Dificulties.Add(dificulty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dificulty);
        }

        // GET: Dificulties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dificulty dificulty = db.Dificulties.Find(id);
            if (dificulty == null)
            {
                return HttpNotFound();
            }
            return View(dificulty);
        }

        // POST: Dificulties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DificultyId,Name")] Dificulty dificulty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dificulty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dificulty);
        }

        // GET: Dificulties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dificulty dificulty = db.Dificulties.Find(id);
            if (dificulty == null)
            {
                return HttpNotFound();
            }
            return View(dificulty);
        }

        // POST: Dificulties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dificulty dificulty = db.Dificulties.Find(id);
            db.Dificulties.Remove(dificulty);
            db.SaveChanges();
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
