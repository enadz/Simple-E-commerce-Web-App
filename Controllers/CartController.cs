using apshop.BLL;
using apshop.Data.Models;
using apshop.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apshop.Controllers
{
    public class CartController : ControllerBase
    {

        private readonly ICartService _cartService;
        private readonly IItemRepository _itemRepository;
        public CartController(ICartService cartService, IItemRepository itemRepository)
        {
            _cartService=cartService;
            _itemRepository = itemRepository;
        }

        [HttpPost]
        public IActionResult AddToCart(Item item)
        {
            _cartService.AddToCart(item.itemId);
            
            return Ok(item);
        }


        [HttpDelete("{itemCode}")]
        public IActionResult RemoveFromShoppingCart(int itemCode)
        {
            
             _cartService.RemoveFromCartByCode(itemCode);
            
            return Ok();
        }

    }
}
