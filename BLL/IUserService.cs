using apshop.Data.Models;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apshop.BLL
{
    public interface IUserService
    {
        public Optional<User> GetUserById(int userId);
        public bool Authenticate(string username, string password);
        public void Register(string username, string password);
        public bool CheckIfUserExists(string username);
        public Cart GetMyCart(int userId);
        public List<Order> GetMyOrders(int userId);
        public void ClearMyCart(int cartId);
    }
}
