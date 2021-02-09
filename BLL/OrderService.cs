using apshop.Data;
using apshop.Data.Models;
using apshop.Repositories.Interfaces;
using apshop.Repositories.Repositories;
using apshop.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apshop.BLL
{
    public class OrderService:IOrderService
    {

        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order GetOrderById(int orderId)
        {

            return _orderRepository.GetOrderById(orderId);

        }
        public List<Order> GetOrdersByUserId(int userId)
        {
            return _orderRepository.GetOrdersByUserId(userId);

        }
        public void UpdateOrder(Order order)
        {
            _orderRepository.UpdateOrder(order);
        }
        public void DeleteOrder(Order order)
        {
            _orderRepository.DeleteOrder(order);

        }
        public Order AddOrder(Order order)
        {
           
            return _orderRepository.AddOrder(order);
        }
    }
}
