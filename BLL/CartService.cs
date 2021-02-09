using apshop.Data.Models;
using apshop.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apshop.BLL
{
    public class CartService:ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IItemRepository _itemRepository;

        
        public CartService(ICartRepository cartRepository, IItemRepository itemRepository)
        {
            _cartRepository = cartRepository;
            _itemRepository = itemRepository;
        }
        public void AddToCart(int itemId)
        {
            var selectedItem = _itemRepository.items.FirstOrDefault(p => p.itemId == itemId);
            if (selectedItem != null)
            {
                _cartRepository.AddToCart(selectedItem, 1);
            }
        }

       

        public void RemoveFromCartByCode(int itemCode)
        {
            _cartRepository.DeleteCartItem(itemCode);
          
        }

    }
}
