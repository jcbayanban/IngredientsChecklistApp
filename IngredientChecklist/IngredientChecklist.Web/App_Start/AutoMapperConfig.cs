using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using IngredientChecklist.Entity.Entity;
using IngredientChecklist.Dto.Entity;

namespace IngredientChecklist.Web.App_Start
{
    public static class AutoMapperConfig
    {
        public static void CreateMaps()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<Recipe, RecipeDto>().ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.Ingredients));
            });
        }
    }
}