using CRUDAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDAPI.Repository.Abstract
{
   public interface IUserRepository
    {
        List<User> GetAllUsers();
        void AddUser(User user);
        bool RemoveUser(int id);
        bool UpdateUser(User user);
        User GetUserById(int id);
    }
}
