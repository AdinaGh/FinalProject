using DataAccess.Interfaces;
using Entities.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CommentService : Service<Comment>, ICommentService
    {
        public CommentService(IRepository<Comment> repository) : base(repository)
        {
        }

        public void DeleteByRecipe(int recipeId)
        {
            var items = Filter(rc => rc.RecipeId == recipeId).ToList();
            foreach (var item in items)
            {
                Delete(item.CommentId);
            }
        }
    }
}
