﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class CommentModel
    {
        public int CommentId { get; set; }
        public string Description { get; set; }
        public int RecipeId { get; set; }
        public int UserId { get; set; }

        //public Recipe Recipe { get; set; }

    }
}