using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserRatingService : IService<UserRating>
    {
        void DeleteByRecipe(int recipeId);
    }
}
