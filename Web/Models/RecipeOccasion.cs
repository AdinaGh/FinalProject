//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RecipeOccasion
    {
        public int RecipeOccasionId { get; set; }
        public int RecipeId { get; set; }
        public int OccasionId { get; set; }
    
        public virtual Occasion Occasion { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}