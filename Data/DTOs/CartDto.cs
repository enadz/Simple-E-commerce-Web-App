using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apshop.Data.DTOs
{
    public class CartDto
    {
        public int cartId { get; set; }
        public int userId { get; set; }
        public string lastUpdateDate{ get; set; }
    }
}
