namespace Web.Models
{
    public class RecipeIngredientModel
    {
        public int RecipeIngredientId { get; set; }
        public int RecipeId { get; set; }
        public string Ingredient { get; set; }

        //public Recipe Recipe { get; set; }

    }
}