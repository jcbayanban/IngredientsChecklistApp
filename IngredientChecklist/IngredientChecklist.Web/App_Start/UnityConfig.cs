using System.Web.Http;
using Unity;
using Unity.WebApi;
using IngredientChecklist.Application.IRepository;
using IngredientChecklist.Application.Repository;


namespace IngredientChecklist.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IRecipeRepository, RecipeRepository>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}