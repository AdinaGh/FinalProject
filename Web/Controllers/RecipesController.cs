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
    public class RecipesController : Controller
    {
        private IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }
        // GET: Recipes
        public ActionResult Index()
        {
            var recipes = _recipeService
                .GetAll()
                .Select(ca => new RecipeViewModel()
                {
                    RecipeId = ca.RecipeId,
                    ImageUrl = ca.ImageUrl,
                    Title = ca.Title
                });
            return View(recipes);
        }

        // GET: Recipes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var recipe = _recipeService.GetById(id.Value);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(
                EntityToView(recipe)
                );
        }

        // GET: Recipes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecipeId,CreatedUserId,CreatedDate,CuisineId,DificultyId,Notes,PreparationMinutes,TotalMinutes,Serves,ImageUrl,Title")] RecipeViewModel recipe)
        {
            if (ModelState.IsValid)
            {
                _recipeService.Add(new Recipe()
                {
                    RecipeId = recipe.RecipeId,
                    Title = recipe.Title,
                    ImageUrl = recipe.ImageUrl
                }); 
                return RedirectToAction("Index");
            }

            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var recipe = _recipeService.GetById(id.Value);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(EntityToView(recipe));
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
                _recipeService.Update(new Recipe()
                {
                    RecipeId = recipe.RecipeId,
                    ImageUrl = recipe.ImageUrl,
                    Title = recipe.Title
                });
                return RedirectToAction("Index");
            }
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var recipe = _recipeService.GetById(id.Value);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(new RecipeViewModel()
            {
                Title = recipe.Title,
                RecipeId = recipe.RecipeId,
                ImageUrl= recipe.ImageUrl
            });
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _recipeService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _recipeService.Dispose();
            }
            base.Dispose(disposing);
        }

        private static RecipeViewModel EntityToView(Recipe recipe)
        {
            return new RecipeViewModel()
            {
                Cuisine = new CuisineModel() { CuisineId = recipe.Cuisine.CuisineId, Name = recipe.Cuisine.Name },
                Dificulty = new DificultyModel() { Name = recipe.Dificulty.Name, DificultyId = recipe.Dificulty.DificultyId },
                Notes = recipe.Notes,
                PreparationMinutes = recipe.PreparationMinutes,
                RecipeCategories = recipe.RecipeCategories.Select(rc => new RecipeCategoryModel()
                {
                    Category = new CategoryViewModel() { Name = rc.Category.Name, CategoryId = rc.Category.CategoryId },
                    CategoryId = rc.CategoryId,
                    RecipeCategoryId = rc.RecipeCategoryId,
                    RecipeId = rc.RecipeId
                }).ToList(),
                ImageUrl = recipe.ImageUrl,
                Title = recipe.Title,
                Comments = recipe.Comments.Select(co => new CommentModel() { RecipeId = co.RecipeId, CommentId = co.CommentId, Description = co.Comment1 }).ToList(),
                RecipeIngredients = recipe.RecipeIngredients.Select(ri => new RecipeIngredientModel() { RecipeId = ri.RecipeId, Ingredient = ri.Ingredient, RecipeIngredientId = ri.RecipeIngredientId }).ToList(),
                RecipeOccasions = recipe.RecipeOccasions.Select(oc => new RecipeOccasionModel()
                {
                    RecipeId = oc.RecipeId,
                    OccasionId = oc.OccasionId,
                    RecipeOccasionId = oc.RecipeOccasionId,
                    Occasion = new OccasionModel() { Name = oc.Occasion.Name, OccasionId = oc.Occasion.OccasionId }

                }).ToList(),
                RecipeSteps = recipe.RecipeSteps.OrderBy(st => st.Step).Select(st => new RecipeStepModel() { RecipeId = st.RecipeId, Description = st.Description, RecipeStepId = st.RecipeStepId, Step = st.Step }).ToList(),
                Serves = recipe.Serves,
                TotalMinutes = recipe.TotalMinutes,
                UserRatings = recipe.UserRatings.Select(ur => new UserRatingModel() { RecipeId = ur.RecipeId, Rating = ur.Rating, UserId = ur.UserId, UserRatingId = ur.UserRatingId }).ToList()
            };
        }

    }
}
