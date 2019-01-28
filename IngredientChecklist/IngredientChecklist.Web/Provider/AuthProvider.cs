using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.OAuth;
using System.Threading.Tasks;
using System.Security.Claims;
using  IngredientChecklist.Application.Repository;

namespace IngredientChecklist.Web.Provider
{
    public class AuthProvider : OAuthAuthorizationServerProvider
    {
        public AuthProvider()
        {
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {

            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            UserRepository _userRepository = new UserRepository();
            var user = _userRepository.GetUserByUserName(context.UserName);
            if (user == null)
            {
                context.SetError("invalid_grant", "Invalid username and/or password.");
                return Task.FromResult<object>(null);
            }
            else
            {
                if (user.Password != context.Password)
                {
                    context.SetError("invalid_grant", "Invalid username and/or password.");
                    return Task.FromResult<object>(null);
                }                
                else
                {
                    var identity = new ClaimsIdentity("JWT");
                    identity.AddClaim(new Claim(ClaimTypes.Name, user.Id.ToString()));
                    identity.AddClaim(new Claim("UserId", user.Id.ToString()));
                    var ticket = new Microsoft.Owin.Security.AuthenticationTicket(identity, null);
                    context.Validated(ticket);                    
                    return base.GrantResourceOwnerCredentials(context);
                }
            }
        }
    }
}