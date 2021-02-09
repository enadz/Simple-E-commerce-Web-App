using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apshop.Data.DTOs
{
    public class ItemDto
    {

        public int itemId { get; set; }
        public string name { get; set; }
        public string imageUrl { get; set; }
        public string shortDescription { get; set; }
        public double price { get; set; }
      
    }
}
