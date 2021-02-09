using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apshop.Data.Models
{
    public class Cart
    {

        public int cartId { get; set; }
        public int userId { get; set; }
  
        public DateTime? lastUpdateDate { get; set; }

        public double totalPrice { get; set; }
        public double totalShipingPrice { get; set; }
        public virtual User user { get; set; }
        public virtual ICollection<CartItem> cartItems { get; set; }
      

    }
}
