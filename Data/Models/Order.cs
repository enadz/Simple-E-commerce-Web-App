using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apshop.Data.Models
{
    public class Order
    {
        public int orderId { get; set; }
        public int orderItemId { get; set; }
        public int itemCode { get; set; }
        public int userId { get; set; }
        public DateTime date { get; set; }
        public double totalPrice { get; set; }
        public virtual ICollection<OrderItem> orderItems { get; set; }
        public virtual User user { get; set; }
    }
}
