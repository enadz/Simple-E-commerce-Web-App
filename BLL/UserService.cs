using apshop.Data.Models;
using apshop.Mapper;
using apshop.Repositories.Interfaces;
using apshop.Repositories.Repositories;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apshop.BLL
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IOrderRepository _orderRepository;

        public UserService(IUserRepository userRepository,ICartRepository cartRepository, IOrderRepository orderRepository)
        {
            _userRepository = userRepository;
            _cartRepository = cartRepository;
            _orderRepository = orderRepository;
        }

        public Optional<User> GetUserById(int userId)
        {
            Optional<User> user = _userRepository.GetUserById(userId);
            return user;
        }

        public bool Authenticate(string username, string password)
        {
            if (_userRepository.CheckIfUserExists(username) && _userRepository.LogIn(username, password)) return true;
            else return false;
        }

        public void Register(string username, string password)
        {
            if (!_userRepository.CheckIfUserExists(username))
            {
                
                User user = new User(username, password);

                _userRepository.AddUser(user);
            }

        }

        public bool CheckIfUserExists(string username)
        {
            return _userRepository.CheckIfUserExists(username);
        }

        public Cart GetMyCart(int userId)
        {
            return _cartRepository.GetByUserId(userId);

        }

        public void ClearMyCart(int cartId)
        {

            _cartRepository.ClearCart(cartId);


        }

        public List<Order> GetMyOrders(int userId)
        {
            return _orderRepository.GetOrdersByUserId(userId);
        }

    }
}
