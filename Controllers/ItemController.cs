using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apshop.Repositories.Interfaces;
using apshop.Data.Models;
using Microsoft.AspNetCore.Mvc;
using apshop.BLL.Services;
using apshop.BLL;
using Microsoft.AspNetCore.Authorization;

namespace apshop.Controllers
{
    [Route("api/item")]
    [ApiController]
    public class ItemController :ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IItemService _itemService;
        public ItemController(ICategoryRepository categoryRepository, IItemService itemService)
        {
            _categoryRepository = categoryRepository;
            _itemService = itemService;
        }

        [HttpGet("all")]
        public IActionResult GetAllItems()
        {
            List<Item> items;
            try
            {
                items = _itemService.GetAllItems();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(items);
        }

        

        [HttpGet("{itemId}")]
        public IActionResult GetItemById(int itemId)
        {
            Item item;
            try
            {
                item = _itemService.GetItemById(itemId);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(item);
        }

        [HttpDelete("{itemId}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteItem(int itemId)
        {
         
            if (_itemService.ItemExists(itemId))
            {
                _itemService.DeleteItemById(itemId);

                return Ok();
            }
            else return BadRequest();
        
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult NewItem([FromBody]Item item)
        {

            _itemService.AddItem(item);

            return Ok(item);

        }

        [HttpGet("search")]
        public IActionResult Search([FromHeader] Filter filter)
        {
            return Ok(_itemService.Filter(filter));
        }
    }
}
