using System;

namespace Web.Models
{
    public class CommentModel
    {
        public int CommentId { get; set; }
        public string Description { get; set; }
        public int RecipeId { get; set; }
        public int UserId { get; set; } = 1;

        public DateTime CreatedDate { get; set; }

        public string DisplayCreatedDate { 
            get
            {
                if (CreatedDate == null)
                {
                    return "";
                }

                return CreatedDate.ToShortDateString();
            }
        }

        //public Recipe Recipe { get; set; }

    }
}