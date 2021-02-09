using apshop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apshop.Repositories.Interfaces
{
    public interface ICartRepository
    {
        void CreateCart(Cart cart);
        Cart GetByUserId(int userId);
        List<CartItem> GetAllCartItemsByCartId(int id);
        CartItem GetCartItemById(int cartItemId);
        CartItem GetCartItemByCode(int itemCode);
        public void DeleteCartItem(int itemCode);
        public void UpdateCartItem(int userId, int cartItemId, int quantity, DateTime date);
        public void AddToCart(Item Item, int quantity);
        public void DeleteFromCart(CartItem cartItem);
        public void ClearCart(int cartId);
        public double GetTotal(int cartId);

    }
}
