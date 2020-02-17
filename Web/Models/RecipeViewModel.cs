using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Web.Models
{
    public class RecipeViewModel
    {
        public RecipeViewModel()
        {
            this.Comments = new HashSet<CommentModel>();
            this.RecipeCategories = new HashSet<RecipeCategoryModel>();
            this.RecipeIngredients = new HashSet<RecipeIngredientModel>();
            this.RecipeOccasions = new HashSet<RecipeOccasionModel>();
            this.RecipeSteps = new HashSet<RecipeStepModel>();
            this.UserRatings = new HashSet<UserRatingModel>();
        }

        public string Notes { get; set; }
        public Nullable<int> PreparationMinutes { get; set; }
        public Nullable<int> TotalMinutes { get; set; }
        public Nullable<int> Serves { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }

        public ICollection<CommentModel> Comments { get; set; }
        public CuisineModel Cuisine { get; set; }
        public DificultyModel Dificulty { get; set; }
        public ICollection<RecipeCategoryModel> RecipeCategories { get; set; }
        public ICollection<RecipeIngredientModel> RecipeIngredients { get; set; }
        public ICollection<RecipeOccasionModel> RecipeOccasions { get; set; }
        public ICollection<RecipeStepModel> RecipeSteps { get; set; }
        public ICollection<UserRatingModel> UserRatings { get; set; }
        public int RecipeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUserId { get; set; }
        public int CuisineId { get; set; }
        public int DificultyId { get; set; }
    }
}