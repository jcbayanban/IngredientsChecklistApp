//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IngredientChecklist.Entity.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> RecipeId { get; set; }
        public Nullable<bool> IsChecked { get; set; }
    
        public virtual Recipe Recipe { get; set; }
    }
}
