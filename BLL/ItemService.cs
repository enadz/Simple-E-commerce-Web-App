using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apshop.Data.Models;
using apshop.Repositories.Interfaces;
using apshop.Repositories.Repositories;
using Microsoft.CodeAnalysis;

namespace apshop.BLL.Services
{
    public class ItemService :  IItemService
    {

        private readonly IItemRepository _itemRepository;
        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public Item GetItemById(int itemId)
        {
            Item item = _itemRepository.GetItemById(itemId);
            return item;
        }

        public List<Item> GetAllItems()
        {
            List<Item> item = _itemRepository.GetAllItems();
            return item;
        }

        public bool ItemExists(int itemId)
        {
            if (_itemRepository.CheckIfItemExists(itemId)) return true;
            else return false;
        }
        public List<Item> Filter(Filter filter)
        {
            List<Item> item = _itemRepository.Filter(filter);
            return item;
        }
        public void DeleteItemById(int itemId)
        {
            if (_itemRepository.CheckIfItemExists(itemId))
            {
                _itemRepository.DeleteItemById(itemId);
                
            }
           
        }

        public void AddItem(Item item)
        {
            _itemRepository.AddItem(item);
        }



    }
}
