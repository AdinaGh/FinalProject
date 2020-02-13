using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class RecipeViewModel
    {
        public RecipeViewModel()
        {
            //this.Comments = new HashSet<Comment>();
            //this.RecipeCategories = new HashSet<RecipeCategory>();
            //this.RecipeIngredients = new HashSet<RecipeIngredient>();
            //this.RecipeOccasions = new HashSet<RecipeOccasion>();
            //this.RecipeSteps = new HashSet<RecipeStep>();
            //this.UserRatings = new HashSet<UserRating>();

        }
        public int RecipeId { get; set; }
        //public int CreatedUserId { get; set; }
        //public System.DateTime CreatedDate { get; set; }
        //public int CuisineId { get; set; }
        //public int DificultyId { get; set; }
        //public string Notes { get; set; }
        //public Nullable<int> PreparationMinutes { get; set; }
        //public Nullable<int> TotalMinutes { get; set; }
        //public Nullable<int> Serves { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        //public List<Comment> Comments { get; set; }
        //public Cuisine Cuisine { get; set; }
        //public Dificulty Dificulty { get; set; }
        //public List<RecipeCategory> RecipeCategories { get; set; }
        //public List<RecipeIngredient> RecipeIngredients { get; set; }
        //public List<RecipeOccasion> RecipeOccasions { get; set; }
        //public List<RecipeStep> RecipeSteps { get; set; }
        //public List<UserRating> UserRatings { get; set; }

    }
}