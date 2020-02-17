
namespace Web.Models
{
    public class RecipeOccasionModel
    {
        public int RecipeOccasionId { get; set; }
        public int RecipeId { get; set; }
        public int OccasionId { get; set; }

        public OccasionModel Occasion { get; set; }
        //public Recipe Recipe { get; set; }

    }
}