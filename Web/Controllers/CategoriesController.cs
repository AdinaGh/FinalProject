using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entities.Models;
using Services.Interfaces;
using Web.Models;

namespace Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: Categories
        //[ValidateAntiForgeryToken]
        public ActionResult Index()
        {
            var categories = _categoryService
                .GetAll()
                .Select(ca => new CategoryViewModel()
                {
                    Name = ca.Name,
                    CategoryId = ca.CategoryId,
                    //RecipeCategories = ca.RecipeCategories
                });
            return View(categories);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = _categoryService.GetById(id.Value);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(new CategoryViewModel()
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                //RecipeCategories = category.RecipeCategories
            });
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,Name")] CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Add(new Category()
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                });
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            var category = _categoryService.GetById(id.Value);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(new CategoryViewModel()
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                //RecipeCategories = category.RecipeCategories
            });
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,Name")] CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Update(new Category()
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name
                });
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = _categoryService.GetById(id.Value);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(new CategoryViewModel()
            {
                Name = category.Name,
                CategoryId=category.CategoryId,
                //RecipeCategories = category.RecipeCategories
            });
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _categoryService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _categoryService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
