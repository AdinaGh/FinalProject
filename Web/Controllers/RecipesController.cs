﻿using System;
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
    public class RecipesController : Controller
    {
        private RecipesDataContext db = new RecipesDataContext();

        // GET: Recipes
        public ActionResult Index()
        {
            var recipes = db.Recipes.Include(r => r.Cuisine).Include(r => r.Dificulty);
            return View(recipes.ToList());
        }

        // GET: Recipes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // GET: Recipes/Create
        public ActionResult Create()
        {
            ViewBag.CuisineId = new SelectList(db.Cuisines, "CuisineId", "Name");
            ViewBag.DificultyId = new SelectList(db.Dificulties, "DificultyId", "Name");
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecipeId,CreatedUserId,CreatedDate,CuisineId,DificultyId,Notes,PreparationMinutes,TotalMinutes,Serves,ImageUrl,Title")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Recipes.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CuisineId = new SelectList(db.Cuisines, "CuisineId", "Name", recipe.CuisineId);
            ViewBag.DificultyId = new SelectList(db.Dificulties, "DificultyId", "Name", recipe.DificultyId);
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            ViewBag.CuisineId = new SelectList(db.Cuisines, "CuisineId", "Name", recipe.CuisineId);
            ViewBag.DificultyId = new SelectList(db.Dificulties, "DificultyId", "Name", recipe.DificultyId);
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecipeId,CreatedUserId,CreatedDate,CuisineId,DificultyId,Notes,PreparationMinutes,TotalMinutes,Serves,ImageUrl,Title")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CuisineId = new SelectList(db.Cuisines, "CuisineId", "Name", recipe.CuisineId);
            ViewBag.DificultyId = new SelectList(db.Dificulties, "DificultyId", "Name", recipe.DificultyId);
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipe recipe = db.Recipes.Find(id);
            db.Recipes.Remove(recipe);
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
