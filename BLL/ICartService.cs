using apshop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apshop.BLL
{
    public interface ICartService
    {
        public void AddToCart(int itemId);
        public void RemoveFromCartByCode(int itemCode);

    }
}
