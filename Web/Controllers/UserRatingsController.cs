using Entities.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserRatingsController : Controller
    {
        private RecipesDataContext db = new RecipesDataContext();

        // GET: UserRatings
        public ActionResult Index()
        {
            var userRatings = db.UserRatings.Include(u => u.Recipe);
            return View(userRatings.ToList());
        }

        // GET: UserRatings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRating userRating = db.UserRatings.Find(id);
            if (userRating == null)
            {
                return HttpNotFound();
            }
            return View(userRating);
        }

        // GET: UserRatings/Create
        public ActionResult Create()
        {
            ViewBag.RecipeId = new SelectList(db.Recipes, "RecipeId", "Title");
            return View();
        }

        // POST: UserRatings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserRatingViewModel userRating)
        {
            if (ModelState.IsValid)
            {
                var userRatingMap = MapViewToEntity(userRating);
                db.UserRatings.Add(userRatingMap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RecipeId = new SelectList(db.Recipes, "RecipeId", "Title", userRating.RecipeId);
            return View(userRating);
        }

        private UserRating MapViewToEntity(UserRatingViewModel userRating)
        {
            return new UserRating()
            {
                RecipeId = userRating.RecipeId,
                UserId = userRating.UserId,
                Rating = userRating.Rating
            };
        }

        // GET: UserRatings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRating userRating = db.UserRatings.Find(id);
            if (userRating == null)
            {
                return HttpNotFound();
            }
            ViewBag.RecipeId = new SelectList(db.Recipes, "RecipeId", "Title", userRating.RecipeId);
            return View(MapEntityToView(userRating));
        }

        private UserRatingViewModel MapEntityToView(UserRating rating)
        {
            return new UserRatingViewModel()
            {
                Rating = rating.Rating,
                RecipeId = rating.RecipeId,
                UserId = rating.UserId,
                UserRatingId = rating.UserRatingId
            };
        }

        // POST: UserRatings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserRatingId,RecipeId,UserId,Rating")] UserRating userRating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userRating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RecipeId = new SelectList(db.Recipes, "RecipeId", "Title", userRating.RecipeId);
            return View(userRating);
        }

        // GET: UserRatings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRating userRating = db.UserRatings.Find(id);
            if (userRating == null)
            {
                return HttpNotFound();
            }
            return View(userRating);
        }

        // POST: UserRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserRating userRating = db.UserRatings.Find(id);
            db.UserRatings.Remove(userRating);
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
