using Entities.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CommentsController : Controller
    {
        private RecipesDataContext db = new RecipesDataContext();

        // GET: Comments
        public ActionResult Index()
        {
            var comments = db.Comments.Include(c => c.Recipe);
            return View(comments.ToList().Select(co => MapEntityToView(co)).ToList());
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(MapEntityToView(comment));
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            ViewBag.RecipeId = new SelectList(db.Recipes, "RecipeId", "Title");
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentViewModel comment)
        {
            if (ModelState.IsValid)
            {
                var commentMap = MapViewToEntity(comment);
                commentMap.CreatedDate = DateTime.Now;
                db.Comments.Add(commentMap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RecipeId = new SelectList(db.Recipes, "RecipeId", "Title", comment.RecipeId);
            return View(comment);
        }

        private Comment MapViewToEntity(CommentViewModel comment)
        {
            return new Comment()
            {
                RecipeId = comment.RecipeId,
                Comment1 = comment.Description,
                UserId = comment.CreatedUserId,
                CreatedDate = comment.CreatedDate,
                CommentId = comment.CommentId
            };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddReview(RecipeViewModel recipe)
        {
            if (recipe?.AddComments != null)
            {
                db.Comments.Add(new Comment()
                {
                    RecipeId = recipe.RecipeId,
                    UserId = recipe.CreatedUserId,
                    Comment1 = recipe.AddComments,
                });
                db.SaveChanges();
            }
            return RedirectToAction("Details", "Recipes", new { id = recipe.RecipeId });
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.RecipeId = new SelectList(db.Recipes, "RecipeId", "Title", comment.RecipeId);
            var commentModel = MapEntityToView(comment);
            return View(commentModel);
        }

        private CommentViewModel MapEntityToView(Comment comment)
        {
            return new CommentViewModel()
            {
                Description = comment.Comment1,
                CommentId = comment.CommentId,
                RecipeId = comment.RecipeId,
                CreatedDate = comment.CreatedDate,
                RecipeTitle = comment.Recipe.Title
            };
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CommentViewModel comment)
        {
            if (ModelState.IsValid)
            {
                var originalComment = db.Comments.Find(comment.CommentId);
                originalComment.RecipeId = comment.RecipeId;
                originalComment.Comment1 = comment.Description;

                db.Entry(originalComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RecipeId = new SelectList(db.Recipes, "RecipeId", "Title", comment.RecipeId);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(MapEntityToView(comment));
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
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
