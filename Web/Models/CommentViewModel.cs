using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }
        public string Description { get; set; }
        public int RecipeId { get; set; }
        [Range(1, int.MaxValue)]
        public int CreatedUserId { get; set; } = 1;
        public DateTime CreatedDate { get; internal set; }

        [Display(Name = "Recipe")]
        public string RecipeTitle { get; set; }

    }
}