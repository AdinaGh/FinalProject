using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Entities.Models;
using Services.Interfaces;
using Web.Models;

namespace Web.Controllers
{    
    public class RecipesController : Controller
    {
        private readonly IRecipeService _recipeService;
        private readonly IRecipeIngredientService _recipeIngredientService;
        private readonly IRecipeCategoryService _recipeCategoryService;
        private readonly IRecipeOccasionService _recipeOccasionService;
        private readonly IRecipeStepService _recipeStepService;
        private readonly IUserRatingService _userRatingService;
        private readonly ICuisineService _cuisineService;
        private readonly IDificultyService _difficultyService;
        private readonly ICommentService _commentService;

        public RecipesController(IRecipeService recipeService,
            ICuisineService cuisineService,
            IDificultyService difficultyService,
              IRecipeIngredientService recipeIngredientService,
        IRecipeCategoryService recipeCategoryService,
        IRecipeOccasionService recipeOccasionService,
        IRecipeStepService recipeStepService,
        IUserRatingService userRatingService,
        ICommentService commentService

            )
        {
            _recipeService = recipeService;
            _cuisineService = cuisineService;
            _difficultyService = difficultyService;
            _recipeCategoryService = recipeCategoryService;
            _recipeIngredientService = recipeIngredientService;
            _recipeOccasionService = recipeOccasionService;

            _recipeStepService = recipeStepService;
            _userRatingService = userRatingService;
            _commentService = commentService;
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
                MapEntityToView(recipe)
                );
        }

        // GET: Recipes/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.CuisineId = new SelectList(_cuisineService.GetAll(), "CuisineId", "Name");
            ViewBag.DificultyId = new SelectList(_difficultyService.GetAll(), "DificultyId", "Name");

            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(
        RecipeViewModel recipe)
        {
             //User.Identity.Name;
            if (ModelState.IsValid)
            {
                var recipeMap = MapViewToEntity(recipe);
                recipeMap.CreatedDate = DateTime.Now;
                _recipeService.Add(recipeMap); 
                return RedirectToAction("Index");
            }


            ViewBag.CuisineId = new SelectList(_cuisineService.GetAll(), "CuisineId", "Name", recipe.CuisineId);
            ViewBag.DificultyId = new SelectList(_difficultyService.GetAll(), "DificultyId", "Name", recipe.DificultyId);
            
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        [Authorize(Roles = "Admin")]
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


            ViewBag.CuisineId = new SelectList(_cuisineService.GetAll(), "CuisineId", "Name", recipe.Dificulty);
            ViewBag.DificultyId = new SelectList(_difficultyService.GetAll(), "DificultyId", "Name", recipe.DificultyId);

            return View(MapEntityToView(recipe));
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(
            RecipeViewModel recipe)
        {
            if (ModelState.IsValid)
            {
                _recipeService.Update(MapViewToEntity(recipe));
                return RedirectToAction("Index");
            }

            ViewBag.CuisineId = new SelectList(_cuisineService.GetAll(), "CuisineId", "Name", recipe.CuisineId);
            ViewBag.DificultyId = new SelectList(_difficultyService.GetAll(), "DificultyId", "Name", recipe.DificultyId);

            return View(recipe);
        }

        // GET: Recipes/Delete/5
        [Authorize(Roles = "Admin")]
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
            return View(MapEntityToView(recipe));
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            _recipeIngredientService.DeleteByRecipe(id);
            _recipeCategoryService.DeleteByRecipe(id);
            _recipeOccasionService.DeleteByRecipe(id);
            _recipeStepService.DeleteByRecipe(id);
            _userRatingService.DeleteByRecipe(id);
            _commentService.DeleteByRecipe(id);
            _recipeService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _commentService.Dispose();
                _userRatingService.Dispose();
                _recipeStepService.Dispose();
                _recipeCategoryService.Dispose();
                _recipeIngredientService.Dispose();
                _recipeOccasionService.Dispose();
                _recipeService.Dispose();
            }
            base.Dispose(disposing);
        }

        private static RecipeViewModel MapEntityToView(Recipe recipe)
        {
            return new RecipeViewModel()
            {
                TotalMinutes = recipe.TotalMinutes,
                Serves = recipe.Serves,
                Notes = recipe.Notes,
                RecipeId = recipe.RecipeId,
                CuisineId = recipe.CuisineId,
                DificultyId = recipe.DificultyId,
                //CreatedUserId = recipe.CreatedUserId,
                CreatedDate = recipe.CreatedDate,
                ImageUrl = recipe.ImageUrl,
                Title = recipe.Title,
                PreparationMinutes = recipe.PreparationMinutes,

                Cuisine = new CuisineModel() { CuisineId = recipe.Cuisine.CuisineId, Name = recipe.Cuisine.Name },
                Dificulty = new DificultyModel() { Name = recipe.Dificulty.Name, DificultyId = recipe.Dificulty.DificultyId },
                RecipeCategories = recipe.RecipeCategories.Select(rc => new RecipeCategoryModel()
                {
                    Category = new CategoryViewModel() { Name = rc.Category.Name, CategoryId = rc.Category.CategoryId },
                    CategoryId = rc.CategoryId,
                    RecipeCategoryId = rc.RecipeCategoryId,
                    RecipeId = rc.RecipeId
                }).ToList(),
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
                
                UserRatings = recipe.UserRatings.Select(ur => new UserRatingViewModel() { RecipeId = ur.RecipeId, Rating = ur.Rating, UserId = ur.UserId, UserRatingId = ur.UserRatingId }).ToList()
            };
        }

        private static Recipe MapViewToEntity(RecipeViewModel recipe)
        {
            return new Recipe()
            {
                CuisineId = recipe.CuisineId,
                DificultyId = recipe.DificultyId,
                Notes = recipe.Notes,
                PreparationMinutes = recipe.PreparationMinutes,
                TotalMinutes = recipe.TotalMinutes,
                Serves = recipe.Serves,
                RecipeId = recipe.RecipeId,
                ImageUrl = recipe.ImageUrl,
                Title = recipe.Title,
              CreatedUserId = recipe.CreatedUserId,
                CreatedDate = recipe.CreatedDate
            };
        }

    }
}
