using apshop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apshop.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        OrderItem AddOrderItem(OrderItem orderitem);
        Order GetOrderById(int orderId);
        public List<Order> GetOrdersByUserId(int userId);
        public void UpdateOrder(Order order);
        public void DeleteOrder(Order order);
        public Order AddOrder(Order order);

    }
}
