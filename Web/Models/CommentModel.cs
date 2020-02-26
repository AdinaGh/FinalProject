namespace Web.Models
{
    public class CommentModel
    {
        public int CommentId { get; set; }
        public string Description { get; set; }
        public int RecipeId { get; set; }
        public int UserId { get; set; } = 1;

        //public Recipe Recipe { get; set; }

    }
}