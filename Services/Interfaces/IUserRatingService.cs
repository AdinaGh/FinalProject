using Entities.Models;

namespace Services.Interfaces
{
    public interface IUserRatingService : IService<UserRating>
    {
        void DeleteByRecipe(int recipeId);
    }
}
