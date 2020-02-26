using Entities.Models;

namespace Services.Interfaces
{
    public interface ICommentService : IService<Comment>
    {
        void DeleteByRecipe(int recipeId);
    }
}
