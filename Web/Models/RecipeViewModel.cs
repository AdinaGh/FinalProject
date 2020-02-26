using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Web.Models
{
    public class RecipeViewModel
    {
        const string _displayPrepUnit = "minutes";
        public RecipeViewModel()
        {
            this.Comments = new HashSet<CommentModel>();
            this.RecipeCategories = new HashSet<RecipeCategoryModel>();
            this.RecipeIngredients = new HashSet<RecipeIngredientModel>();
            this.RecipeOccasions = new HashSet<RecipeOccasionModel>();
            this.RecipeSteps = new HashSet<RecipeStepModel>();
            this.UserRatings = new HashSet<UserRatingViewModel>();
        }

        public string Notes { get; set; }
        [Range(1, int.MaxValue)]
        public Nullable<int> PreparationMinutes { get; set; }
        [Range(1,int.MaxValue)]
        public Nullable<int> TotalMinutes { get; set; }
        [Range(1, int.MaxValue)]
        public Nullable<int> Serves { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        [DisplayName("Recipe Name")]
        public string Title { get; set; }

        public string TitleTrim
        {
            get
            {
                if (Title != null && Title.Length > 25)
                {
                    return Title.Substring(0, 24) + "..";
                }
                return Title;
            }
        }
        public ICollection<CommentModel> Comments { get; set; }
        public CuisineModel Cuisine { get; set; }
        public DificultyModel Dificulty { get; set; }
        public ICollection<RecipeCategoryModel> RecipeCategories { get; set; }
        public ICollection<RecipeIngredientModel> RecipeIngredients { get; set; }
        public ICollection<RecipeOccasionModel> RecipeOccasions { get; set; }
        public ICollection<RecipeStepModel> RecipeSteps { get; set; }
        public ICollection<UserRatingViewModel> UserRatings { get; set; }
        public int RecipeId { get; set; }
        public DateTime CreatedDate { get; set; }

        public string DisplayCreatedDate {
            get
            {
                return CreatedDate == null ? "" : CreatedDate.ToShortDateString();
            }
        }
        [Range(1, int.MaxValue)]
        public int CreatedUserId { 
            get
            {
                return 1;
            }
        }
        public int CuisineId { get; set; }
        public int DificultyId { get; set; }

        public string DisplayPreparationMinutes { 
            get
            {
                if(PreparationMinutes==null)
                {
                    return "";
                }
                else
                {
                    return $"{PreparationMinutes} {_displayPrepUnit}";
                }
            }
        }

        public string DisplayTotalMinutes
        {
            get
            {
                if (TotalMinutes == null)
                {
                    return "";
                }
                else
                {
                    return $"{TotalMinutes} {_displayPrepUnit}";
                }
            }
        }

        [DisplayName("Tell me what you think")]
        public string AddComments { get; set; } = "";
    }
}