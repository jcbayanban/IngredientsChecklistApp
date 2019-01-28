using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngredientChecklist.Entity.Entity;

namespace IngredientChecklist.Application.IRepository
{
    public interface IUserRepository
    {
        User ValidateUser(string userName, string password);

        User GetUserById(int id);
        User GetUserByUserName(string name);
    }
}
