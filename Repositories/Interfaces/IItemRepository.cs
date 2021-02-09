using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apshop.Data.Models;

namespace apshop.Repositories.Interfaces
{
    public interface IItemRepository
    {
        IEnumerable<Item> items { get; }
        Item GetItemById(int itemId);
        public List<Item> GetAllItems();
        public bool CheckIfItemExists(int itemId);
        public bool DeleteItemById(int itemId);
        public List<Item> SearchByNameOnly(string search);
        public List<Item> Filter(Filter filter);
        public void AddItem(Item item);
    }
}
