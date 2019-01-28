using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngredientChecklist.Dto.Entity;
using IngredientChecklist.Entity.Entity;

namespace IngredientChecklist.Application.IRepository
{
    public interface IRecipeRepository
    {
        int AddRecipe(RecipeDto recipeDto);
        List<RecipeDto> GetListRecipe(int userId, string name);
        RecipeDto GetRecipeById(int id);
        int UpdateRecipe(RecipeDto recipeDto);
        List<RecipeDto> GetListRecipeByUser(int userId);
        bool UpdateRecipeIngredient(IngredientDto ingredientDto);
        bool ResetRecipeIngredientSelection(int recipeId);
    }
}
