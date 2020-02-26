using System.Collections.Generic;

namespace Web.Models
{
    public class RecipeListViewModel
    {
        public IList<RecipeViewModel> List { get; set; }
        public string Filter { get; set; }
    }
}