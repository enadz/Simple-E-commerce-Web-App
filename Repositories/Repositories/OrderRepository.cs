using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apshop.Data;
using apshop.Data.Models;
using apshop.Repositories.Interfaces;

namespace apshop.Repositories.Repositories
{
    public class OrderRepository:IOrderRepository
    {
        private ApShopContext _context;

        public OrderRepository(ApShopContext context)
        {
            _context = context;
        }
        public Order GetOrderById(int orderId)
        {
            return _context.orders.Where(p => p.orderId == orderId).FirstOrDefault();
        }
        public List<Order> GetOrdersByUserId(int userId)
        {
            return _context.orders.Where(p => p.userId == userId).ToList();
        }

        public OrderItem AddOrderItem(OrderItem orderItem)
        {
            _context.orderItems.Add(orderItem);
            Item item;
            item= (Item)_context.items.Where(i => i.itemId == orderItem.item.itemId);
            item.inStock -= orderItem.quantity;
            item.sold += orderItem.quantity;
            _context.items.Update(item);
            return _context.orderItems.Where(oi => oi.orderItemId == orderItem.orderItemId).FirstOrDefault();

        }
        
        public Order AddOrder(Order order)
        {
            _context.orders.Add(order);
            _context.SaveChanges();

            return _context.orders.Where(p => p.orderId == order.orderId).FirstOrDefault();
        }


        public void UpdateOrder(Order order)
        {
            _context.orders.Update(order);
            _context.SaveChanges();
        }
        public void DeleteOrder(Order order)
        {
            _context.orders.Remove(order);
            _context.SaveChanges();
        }


    }
}
