
namespace Web.Models
{
    public class RecipeCategoryModel
    {
        public int RecipeCategoryId { get; set; }
        public int RecipeId { get; set; }
        public int CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
        //public Recipe Recipe { get; set; }

    }
}