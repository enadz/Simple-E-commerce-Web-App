using apshop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apshop.BLL
{
    public interface IOrderService
    {
        public Order GetOrderById(int orderId);
        public List<Order> GetOrdersByUserId(int userId);
        public void UpdateOrder(Order order);
        public void DeleteOrder(Order order);
        public Order AddOrder(Order order);
    }
}
