using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IngredientChecklist.Application.IRepository;
using System.Threading.Tasks;
using IngredientChecklist.Entity.Entity;


namespace IngredientChecklist.Application.Repository
{
    public class UserRepository : IUserRepository
    {
        public User ValidateUser(string userName, string password)
        {
            User user;
            using (var context = new IngredientChecklistEntities())
            {
                user = context.Users.FirstOrDefault(u => u.UserName == userName && u.Password == password);
            }
            return user;
        }

        public User GetUserByUserName(string userName)
        {
            User user;
            using (var context = new IngredientChecklistEntities())
            {
                user = context.Users.FirstOrDefault(u => u.UserName == userName);
            }
            return user;
        }

        public User GetUserById(int id)
        {
            User user;
            using (var context = new IngredientChecklistEntities())
            {
                user = context.Users.FirstOrDefault(u => u.Id == id);
            }
            return user;
        }
    }
}
