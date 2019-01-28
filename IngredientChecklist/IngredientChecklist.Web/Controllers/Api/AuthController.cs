using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IngredientChecklist.Application.IRepository;
using System.Security.Claims;

namespace IngredientChecklist.Web.Controllers.Api
{
    [RoutePrefix("api/auth")]
    public class AuthController : BaseController
    {
        private IUserRepository _userRepository;
        public AuthController(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("validate")]
        public IHttpActionResult Validate() 
        {

            var identity = User.Identity as ClaimsIdentity;
            var userId = identity == null ? null : identity.Claims.FirstOrDefault(c => c.Type == "UserId");
            if (userId == null)
                return Ok("");



            var user = _userRepository.GetUserById(Convert.ToInt32(userId.Value));
            var userName = user.UserName;


            return Ok(userName);
        }
    }
}
