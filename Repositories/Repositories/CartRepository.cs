using apshop.Data;
using apshop.Data.Models;
using apshop.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apshop.Repositories.Repositories
{
    public class CartRepository:ICartRepository
    {
        private ApShopContext _apShopContext;
        private DbSet<Cart> _dbSet;
        public CartRepository(ApShopContext context)
        {
            _dbSet = context.carts;
            _apShopContext = context;
        }

        public void CreateCart(Cart cart)
        {
            _dbSet.Add(cart);
        }

        public Cart GetByUserId(int userId)
        {
            try
            {
                return _dbSet.SingleOrDefault(c => c.userId == userId);
            }
            catch (Exception)
            {

                throw new Exception("Cart not found!");
            }
        }

        public CartItem GetCartItemById(int cartItemId)
        {
            var result = _apShopContext.cartItems.SingleOrDefault(c => c.cartItemId == cartItemId);
            if (result == null)
            {
                throw new Exception("Product not found.");
            }
            return result;
        }
        public CartItem GetCartItemByCode(int itemCode)
        {
            var result = _apShopContext.cartItems.SingleOrDefault(c => c.itemCode == itemCode);
            if (result == null)
            {
                throw new Exception("Product not found.");
            }
            return result;
        }

        public void UpdateCartItem(int userId, int cartItemId, int quantity, DateTime date)
        {
            GetCartItemById(cartItemId).quantity = quantity;
            GetByUserId(userId).lastUpdateDate = date;
        }

        public void DeleteCartItem(int itemCode)
        {
            try
            {
                _apShopContext.Remove(GetCartItemByCode(itemCode));
            }
            catch (Exception)
            {

                throw new Exception("Product not found!");
            }
        }

        public List<CartItem> GetAllCartItemsByCartId(int cartId)
        {
           
            List<CartItem> allCartItems;
            List<int> listOfCodes = new List<int>();
            try
            {
                allCartItems= _apShopContext.cartItems.Where(c => c.cartId == cartId).ToList();
            }
            catch (Exception)
            {
                throw new Exception("The cart is empty");
            }

            if (allCartItems == null)
            {
                throw new Exception("The cart is empty");
            }

            foreach (var cartItem in allCartItems)
            {
                listOfCodes.Add(cartItem.itemCode);
            }
            return allCartItems;
        }

        public void AddToCart(Item Item, int quantity)
        {

            if (Item.inStock>quantity || Item.inStock == quantity) {

               CartItem cartItem = new CartItem(Item.itemId, Item.code, quantity);
               
                _apShopContext.cartItems.Add(cartItem);

                _apShopContext.SaveChanges();
            }
        }

        public void  DeleteFromCart(CartItem cartItem)
        {
            
            if (cartItem != null)
            {
                if (cartItem.quantity > 1)
                {
                    cartItem.quantity--;
                }
                else
                {
                    _apShopContext.cartItems.Remove(cartItem);
                }
            }

            _apShopContext.SaveChanges();

        }

        public void ClearCart(int cartId)
        {
            var cartItems = _apShopContext.cartItems.Where(c => c.cartId == cartId);

            _apShopContext.cartItems.RemoveRange(cartItems);

            _apShopContext.SaveChanges();
        }

        public double GetTotal(int cartId)
        {
            double total = _apShopContext.cartItems.Where(c => c.cartId == cartId).Select(c => c.item.price* c.quantity).Sum();
            return total;
        }



    }
}
