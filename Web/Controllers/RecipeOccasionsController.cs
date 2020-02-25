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
    public class RecipeOccasionsController : Controller
    {
        private RecipesDataContext db = new RecipesDataContext();

        // GET: RecipeOccasions
        public ActionResult Index()
        {
            var recipeOccasions = db.RecipeOccasions.Include(r => r.Occasion).Include(r => r.Recipe);
            return View(recipeOccasions.ToList());
        }

        // GET: RecipeOccasions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeOccasion recipeOccasion = db.RecipeOccasions.Find(id);
            if (recipeOccasion == null)
            {
                return HttpNotFound();
            }
            return View(recipeOccasion);
        }

        // GET: RecipeOccasions/Create
        public ActionResult Create()
        {
            ViewBag.OccasionId = new SelectList(db.Occasions, "OccasionId", "Name");
            ViewBag.RecipeId = new SelectList(db.Recipes, "RecipeId", "Title");
            return View();
        }

        // POST: RecipeOccasions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecipeOccasionId,RecipeId,OccasionId")] RecipeOccasion recipeOccasion)
        {
            if (ModelState.IsValid)
            {
                db.RecipeOccasions.Add(recipeOccasion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OccasionId = new SelectList(db.Occasions, "OccasionId", "Name", recipeOccasion.OccasionId);
            ViewBag.RecipeId = new SelectList(db.Recipes, "RecipeId", "Title", recipeOccasion.RecipeId);
            return View(recipeOccasion);
        }

        // GET: RecipeOccasions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeOccasion recipeOccasion = db.RecipeOccasions.Find(id);
            if (recipeOccasion == null)
            {
                return HttpNotFound();
            }
            ViewBag.OccasionId = new SelectList(db.Occasions, "OccasionId", "Name", recipeOccasion.OccasionId);
            ViewBag.RecipeId = new SelectList(db.Recipes, "RecipeId", "Title", recipeOccasion.RecipeId);
            return View(recipeOccasion);
        }

        // POST: RecipeOccasions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecipeOccasionId,RecipeId,OccasionId")] RecipeOccasion recipeOccasion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipeOccasion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OccasionId = new SelectList(db.Occasions, "OccasionId", "Name", recipeOccasion.OccasionId);
            ViewBag.RecipeId = new SelectList(db.Recipes, "RecipeId", "Title", recipeOccasion.RecipeId);
            return View(recipeOccasion);
        }

        // GET: RecipeOccasions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeOccasion recipeOccasion = db.RecipeOccasions.Find(id);
            if (recipeOccasion == null)
            {
                return HttpNotFound();
            }
            return View(recipeOccasion);
        }

        // POST: RecipeOccasions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecipeOccasion recipeOccasion = db.RecipeOccasions.Find(id);
            db.RecipeOccasions.Remove(recipeOccasion);
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
