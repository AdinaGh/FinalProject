using DataAccess.Interfaces;
using Entities.Models;
using Services.Interfaces;
using System.Linq;

namespace Services
{
    public class UserRatingService : Service<UserRating>, IUserRatingService
    {
        public UserRatingService(IRepository<UserRating> repository) : base(repository)
        {
        }

        public void DeleteByRecipe(int recipeId)
        {
            var items = Filter(rc => rc.RecipeId == recipeId).ToList();
            foreach (var item in items)
            {
                Delete(item.UserRatingId);
            }
        }
    }
}
