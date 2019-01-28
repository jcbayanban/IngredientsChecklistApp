using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IngredientChecklist.Application.IRepository;
using IngredientChecklist.Entity.Entity;

namespace IngredientChecklist.Web.Controllers.Api
{
    public class BaseController : ApiController
    {
        private IUserRepository _userRepo;

        public BaseController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public User ActiveUser
        {
            get
            {
                var userId = User.Identity.Name;
                User user = _userRepo.GetUserById(Convert.ToInt16(userId));
                return user;
            }
        }
    }
}
