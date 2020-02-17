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
    public class RecipeCategoriesController : Controller
    {
        private RecipesDataContext db = new RecipesDataContext();

        // GET: RecipeCategories
        public ActionResult Index()
        {
            var recipeCategories = db.RecipeCategories.Include(r => r.Category).Include(r => r.Recipe);
            return View(recipeCategories.ToList());
        }

        // GET: RecipeCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeCategory recipeCategory = db.RecipeCategories.Find(id);
            if (recipeCategory == null)
            {
                return HttpNotFound();
            }
            return View(recipeCategory);
        }

        // GET: RecipeCategories/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            ViewBag.RecipeId = new SelectList(db.Recipes, "RecipeId", "ImageUrl");
            return View();
        }

        // POST: RecipeCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecipeCategoryId,RecipeId,CategoryId")] RecipeCategory recipeCategory)
        {
            if (ModelState.IsValid)
            {
                db.RecipeCategories.Add(recipeCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", recipeCategory.CategoryId);
            ViewBag.RecipeId = new SelectList(db.Recipes, "RecipeId", "ImageUrl", recipeCategory.RecipeId);
            return View(recipeCategory);
        }

        // GET: RecipeCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeCategory recipeCategory = db.RecipeCategories.Find(id);
            if (recipeCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", recipeCategory.CategoryId);
            ViewBag.RecipeId = new SelectList(db.Recipes, "RecipeId", "Title", recipeCategory.RecipeId);
            return View(recipeCategory);
        }

        // POST: RecipeCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecipeCategoryId,RecipeId,CategoryId")] RecipeCategory recipeCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipeCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", recipeCategory.CategoryId);
            ViewBag.RecipeId = new SelectList(db.Recipes, "RecipeId", "ImageUrl", recipeCategory.RecipeId);
            return View(recipeCategory);
        }

        // GET: RecipeCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeCategory recipeCategory = db.RecipeCategories.Find(id);
            if (recipeCategory == null)
            {
                return HttpNotFound();
            }
            return View(recipeCategory);
        }

        // POST: RecipeCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecipeCategory recipeCategory = db.RecipeCategories.Find(id);
            db.RecipeCategories.Remove(recipeCategory);
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
