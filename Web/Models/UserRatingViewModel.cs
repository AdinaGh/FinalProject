using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class UserRatingViewModel
    {
        public int UserRatingId { get; set; }
        public int RecipeId { get; set; }
        public int UserId { get; set; } = 1;
        public byte Rating { get; set; }

        //public Recipe Recipe { get; set; }

    }
}