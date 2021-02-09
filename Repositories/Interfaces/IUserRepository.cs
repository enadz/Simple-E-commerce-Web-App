using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apshop.Data.Models;

namespace apshop.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> users{ get; }
        User GetUserById(int userId);
        public bool CheckIfUserExists(string username);
        public bool LogIn(string username, string password);
        public string hashpass(string password);
        public bool IsAdmin(User user);
        public void AddUser(User user);
    }
}
