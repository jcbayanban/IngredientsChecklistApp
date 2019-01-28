using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IngredientChecklist.Application.IRepository;
using IngredientChecklist.Entity.Entity;
using AutoMapper;
using IngredientChecklist.Dto.Entity;
using IngredientChecklist.Dto.Request;

namespace IngredientChecklist.Web.Controllers.Api
{
    public class AccountController : BaseController
    {
        
        private IUserRepository _userRepository;        
        public AccountController(IUserRepository userRepository) : base(userRepository)
        {            
            _userRepository = userRepository;
        }

        [Authorize]
        [HttpGet]
        [Route("getactiveuser")]
        public IHttpActionResult GetActiveUser()
        {
            var activeUser = ActiveUser;
            var userDto = Mapper.Map<UserDto>(activeUser);
            return Ok(userDto);
        }

        //[AllowAnonymous]
        //[HttpPost]
        //[Route("authenticate")]        
        //public IHttpActionResult Authenticate(LoginRequestDto request)
        //{            
        //    var user = _userRepository.ValidateUser(request.UserName, request.Password);
        //    if (user != null)
        //    {
        //        var tokenString = GenerateJSONWebToken(user);
        //        return Ok(new { token = tokenString });
        //    }

        //    return BadRequest("User does not exist");
        //}

       // private string GenerateJSONWebToken(User userInfo)
       // {
       //     var key = "ThisismySecretKey";
       //     var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
       //     var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

       //     var claims = new[] {
       //         new Claim(ClaimTypes.Name, userInfo.Guid.ToString()),
       //     };

       //     var issuer = _config["Jwt:Issuer"];
       //     var token = new JwtSecurityToken(issuer,
       //_config["Jwt:Issuer"],
       //claims,
       //expires: DateTime.Now.AddMinutes(120),
       //signingCredentials: credentials);

       //     return new JwtSecurityTokenHandler().WriteToken(token);
       // }
    }
}
