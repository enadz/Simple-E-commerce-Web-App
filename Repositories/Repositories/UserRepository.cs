using apshop.BLL;
using apshop.Data;
using apshop.Data.DTOs;
using apshop.Data.Models;
using apshop.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apshop.Repositories.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly ApShopContext _apShopContext;
        private readonly HashingService _hashservice;
       
        public UserRepository(ApShopContext apShopContext, HashingService hashingService)
        {
            _apShopContext = apShopContext;
            _hashservice = hashingService;
        }

        public UserRepository(ApShopContext context)
        {
            _apShopContext.users = context.users;
        }

        public IEnumerable<User> users=> _apShopContext.users.Include(c => c.role);

        public User GetUserById(int userId) => _apShopContext.users.FirstOrDefault(p => p.userId == userId);

               
        public bool CheckIfUserExists(string username)
        {

            if (_apShopContext.users.Where(x => x.username == username).Any()) return true;
            else return false;
            
        }

        public bool LogIn(string username, string password)
        {
            if (_apShopContext.users.Where(x => x.username == username && x.password == hashpass(password)).Any()) return true;
            else return false;
        }

        public string hashpass(string password)
        {
            return _hashservice.GenerateHash("mysalt",password);
        }
       
        public bool IsAdmin(User user)
        {
            if (user.role.name == "admin") return true;
            else return false;

        }

        public void AddUser(User user)
        {
 
            _apShopContext.users.Add(user);
            _apShopContext.SaveChanges();
        }



    }
}

