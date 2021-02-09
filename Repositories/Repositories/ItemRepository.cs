using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apshop.Data.Models;
using apshop.Repositories.Interfaces;
using apshop.Data;
using Microsoft.EntityFrameworkCore;

namespace apshop.Repositories.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApShopContext _apShopContext;
        public ItemRepository(ApShopContext apShopContext)
        {
            _apShopContext = apShopContext;
        }
        public IEnumerable<Item> items => _apShopContext.items.Include(c => c.category);

        public Item GetItemById(int itemId) => _apShopContext.items.FirstOrDefault(p => p.itemId == itemId);
        public List<Item> GetAllItems() { List<Item> p = new List<Item>(_apShopContext.items); return p; }
        
        public bool CheckIfItemExists(int itemId)
        {

            if (_apShopContext.items.Where(x => x.itemId == itemId).Any()) return true;
            else return false;

        }

        public bool DeleteItemById(int itemId)
        {
            _apShopContext.items.Remove(_apShopContext.items.Where(item => item.itemId == itemId).First()); ;
            return true;
        }

        public List<CartItem> GetCartItemsByCode(int itemCode, int cartId){

            return _apShopContext.cartItems.Where(p => p.itemCode == itemCode && p.cartId == cartId).ToList();
        }

        public List<Item> SearchByNameOnly(string search) {
            List<Item> searchresults = new List<Item>(_apShopContext.items.Where(item => item.name.Contains(search)));
            return searchresults;
        }

        public List<Item> Filter (Filter filter)
        {

            List<Item> filterresults = new List<Item>(

                _apShopContext.items.Where(i => i.category.name == filter.category && i.name.Contains(filter.name) && i.price > filter.minPrice && i.price < filter.maxPrice &&
                i.male == filter.male && i.female== filter.female && i.shipingPrice == filter.shippingPrice)
            );

            return filterresults;

        }
        public void AddItem(Item item)
        {
            _apShopContext.items.Add(item);
            _apShopContext.SaveChanges();
        }
    }
}
