using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace apshop.Data.Models
{
    public class Item
    {
        
        public int itemId { get; set; }
        public int? categoryId { get; set; }
        [ForeignKey("categoryId")]
        public virtual Category category { get; set; }
        public int code { get; set; }
        public bool isActive { get; set; }
        public string name { get; set; }
        public string imageUrl { get; set; }
        public bool male { get; set; }
        public bool female { get; set; }
        public string shortDescription { get; set; }
        public double price { get; set; }
        public double shipingPrice { get; set; }
        public int inStock { get; set; }
        public int sold { get; set; }
   
        public virtual ICollection<CartItem> cartitems { get; set; }
        public virtual ICollection<OrderItem> orderitems { get; set; }
    }
}