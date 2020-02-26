using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class RecipeListViewModel
    {
        public IList<RecipeViewModel> List { get; set; }
        public string Filter { get; set; }
    }
}