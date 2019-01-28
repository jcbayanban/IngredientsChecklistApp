using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IngredientChecklist.Application.IRepository;
using AutoMapper;
using IngredientChecklist.Dto.Entity;


namespace IngredientChecklist.Web.Controllers.Api
{
    [RoutePrefix("api/recipe")]
    public class RecipeController : BaseController
    {
        private IUserRepository _userRepository;
        private IRecipeRepository _recipeRepository;

        public RecipeController(IRecipeRepository recipeRepository, IUserRepository userRepository) : base(userRepository)
        {
            _recipeRepository = recipeRepository;
            _userRepository = userRepository;
        }

        [Authorize]
        [HttpPost]
        [Route("addrecipe")]
        public IHttpActionResult AddRecipe(RecipeDto request)
        {
            var activeUser = ActiveUser;
            request.UserId = activeUser.Id;
            var id = _recipeRepository.AddRecipe(request);
            return Ok(id);
        }

        [Authorize]
        [HttpGet]
        [Route("GetListRecipe")]
        public IHttpActionResult GetListRecipe(string name = "")
        {
            var activeUser = ActiveUser;
            List<RecipeDto> response = _recipeRepository.GetListRecipe(activeUser.Id, name);
            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        [Route("getrecipebyid/{id}")]
        public IHttpActionResult GetRecipeById(int id)
        {
            //var recipe = _recipeRepository.GetRecipeById(id);
            //var recipeDto = _mapper.Map<RecipeDto>(recipe);
            RecipeDto recipeDto = _recipeRepository.GetRecipeById(id);
            return Ok(recipeDto);
        }

        [Authorize]
        [HttpPost]
        [Route("updaterecipe")]
        public IHttpActionResult UpdateRecipe(RecipeDto request)
        {
            var id = _recipeRepository.UpdateRecipe(request);
            return Ok();
        }

        [Authorize]
        [HttpGet]
        [Route("getlistrecipebyuser")]
        public IHttpActionResult GetListRecipeByUser()
        {
            var activeUser = ActiveUser;

            List<RecipeDto> listRecipe = new List<RecipeDto>();
            listRecipe = _recipeRepository.GetListRecipeByUser(activeUser.Id);

            return Ok(listRecipe);
        }

        [Authorize]
        [HttpPost]
        [Route("updaterecipeingredient")]
        public IHttpActionResult UpdateRecipeIngredient(IngredientDto ingredientDto)
        {
            bool response = _recipeRepository.UpdateRecipeIngredient(ingredientDto);
            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        [Route("resetrecipeingredientselection/{recipeId}")]
        public IHttpActionResult ResetRecipeIngredientSelection(int recipeId)
        {
            bool response = _recipeRepository.ResetRecipeIngredientSelection(recipeId);
            return Ok(response);
        }
    }
}
