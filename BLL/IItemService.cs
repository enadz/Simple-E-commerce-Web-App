using apshop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apshop.BLL
{
    public interface IItemService
    {
        public Item GetItemById(int itemId);
        public List<Item> GetAllItems();
        public bool ItemExists(int itemId);
        public List<Item> Filter(Filter filter);
        public void DeleteItemById(int itemId);
        public void AddItem(Item item);
    }
}
