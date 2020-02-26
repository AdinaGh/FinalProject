namespace Web.Models
{
    public class RecipeStepModel
    {
        public int RecipeStepId { get; set; }
        public int RecipeId { get; set; }
        public string Description { get; set; }
        public int Step { get; set; }

        //public Recipe Recipe { get; set; }

    }
}