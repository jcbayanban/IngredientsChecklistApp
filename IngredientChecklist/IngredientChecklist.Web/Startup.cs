using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Unity;
using Unity.WebApi;

[assembly: OwinStartup(typeof(IngredientChecklist.Web.Startup))]

namespace IngredientChecklist.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            var myProvider = new IngredientChecklist.Web.Provider.AuthProvider();
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                //#if !Release
                //                AllowInsecureHttp = true,
                //#endif
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(15),
                Provider = myProvider,
                //AccessTokenFormat = new LegionExpress.Web.Providers.CustomJwtFormat("JWT"),
            };
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());


            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }
    }
}
