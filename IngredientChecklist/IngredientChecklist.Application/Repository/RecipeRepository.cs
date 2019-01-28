using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngredientChecklist.Entity.Entity;
using IngredientChecklist.Dto.Entity;
using IngredientChecklist.Application.IRepository;
using AutoMapper;

namespace IngredientChecklist.Application.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        public int AddRecipe(RecipeDto recipeDto)
        {
            Recipe recipe = new Recipe
            {
                Name = recipeDto.Name,
                UserId = recipeDto.UserId,
            };
            foreach (var ing in recipeDto.Ingredients)
            {
                Ingredient ingredient = new Ingredient
                {
                    Name = ing.Name,
                };
                recipe.Ingredients.Add(ingredient);
            }
            using (var context = new IngredientChecklistEntities())
            {
                context.Recipes.Add(recipe);
                context.SaveChanges();
            }
            return recipe.Id;
        }

        public List<RecipeDto> GetListRecipe(int userId, string name)
        {
            List<RecipeDto> listRecipe = new List<RecipeDto>();
            using (var context = new IngredientChecklistEntities())
            {
                var recipes = context.Recipes.Where(r => r.Name.StartsWith(name) && r.UserId == userId);
                foreach (var recipe in recipes)
                {
                    var recipeDto = Mapper.Map<RecipeDto>(recipe);
                    listRecipe.Add(recipeDto);
                }
            }
            return listRecipe;
        }

        public RecipeDto GetRecipeById(int id)
        {
            RecipeDto recipeDto = new RecipeDto();
            using (var context = new IngredientChecklistEntities())
            {
                var recipe = context.Recipes.FirstOrDefault(r => r.Id == id);
                recipeDto = Mapper.Map<RecipeDto>(recipe);
            }
            return recipeDto;
        }

        public int UpdateRecipe(RecipeDto recipeDto)
        {
            int recipeId;
            using (var context = new IngredientChecklistEntities())
            {
                var recipe = context.Recipes.FirstOrDefault(r => r.Id == recipeDto.Id);
                recipeId = recipe.Id;
                recipe.Name = recipeDto.Name;

                var oldIngredients = (from item in recipe.Ingredients select item);
                context.Ingredients.RemoveRange(oldIngredients);
                context.SaveChanges();
                foreach (var ing in recipeDto.Ingredients)
                {
                    Ingredient ingredient = new Ingredient
                    {
                        Name = ing.Name,
                    };
                    recipe.Ingredients.Add(ingredient);
                }

                context.SaveChanges();
            }
            return recipeId;
        }

        public List<RecipeDto> GetListRecipeByUser(int userId)
        {
            List<RecipeDto> listRecipe = new List<RecipeDto>();
            using (var context = new IngredientChecklistEntities())
            {
                var recipes = context.Recipes.Where(r => r.UserId == userId);
                foreach (var recipe in recipes)
                {
                    var recipeDto = Mapper.Map<RecipeDto>(recipe);
                    listRecipe.Add(recipeDto);
                }
            }
            return listRecipe;
        }

        public bool UpdateRecipeIngredient(IngredientDto ingredientDto)
        {
            using (var context = new IngredientChecklistEntities())
            {
                var ingredient = context.Ingredients.FirstOrDefault(i => i.Id == ingredientDto.Id);
                ingredient.IsChecked = ingredientDto.IsChecked;
                context.SaveChanges();
            }

            return true;
        }

        public bool ResetRecipeIngredientSelection(int recipeId)
        {
            using (var context = new IngredientChecklistEntities())
            {
                var ingredients = context.Ingredients.Where(i => i.RecipeId == recipeId);
                foreach (var ingredient in ingredients)
                    ingredient.IsChecked = false;
                context.SaveChanges();
            }
            return true;
        }
    }
}
