using apshop.Data.Models;
using apshop.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apshop.Data.Mocks
{
    public class MockItemRepository : IItemRepository
    {
        private readonly ICategoryRepository categoryRepo = new MockCategoryRepository();

        public IEnumerable<Item> items
        {
            get
            {
                return new List<Item>
                {
                    new Item {

                    itemId = 500, categoryId = 102,
                    code = 1,
                    name = "Teddy",
                    shipingPrice = 0,
                    price= 5,
                    isActive = true,
                    imageUrl ="https://229702-702336-raikfcquaxqncofqfm.stackpathdns.com/12862-large_default/cute-baby-bear-plush-toy-plush-toys-teddy-bear.jpg",
                    male =true, female=true,
                    shortDescription ="fluffy", inStock =43, sold=21

                    },

                    new Item {

                    itemId = 501, categoryId = 102,
                    code = 3,
                    name = "bunny",
                    shipingPrice = 0,
                    price= 7,
                    isActive = true,
                    imageUrl ="https://i.pinimg.com/564x/f6/df/85/f6df85b16f9682ead96468dd4e7495c8.jpg",
                    male =false, female=true,
                    shortDescription ="pink, round, chibi", inStock =30, sold=13

                    },

                    new Item {

                    itemId = 502,
                    code = 201,
                    name = "Nike", categoryId = 202,
                    shipingPrice = 0,
                    price= 7,
                    isActive = true,
                    imageUrl ="https://images.sportsdirect.com/images/products/12126340_l.jpg",
                    male =true, female=false,
                    shortDescription ="sportswear", inStock =155, sold=45

                    },

                };
            }
        }

        public void AddItem(Item item)
        {
            throw new NotImplementedException();
        }

        public bool CheckIfItemExists(int itemId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItemById(int itemId)
        {
            throw new NotImplementedException();
        }

        public List<Item> Filter(Filter filter)
        {
            throw new NotImplementedException();
        }

        public List<Item> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public Item GetItemById(int itemId)
        {
            throw new NotImplementedException();
        }

        public List<Item> SearchByNameOnly(string search)
        {
            throw new NotImplementedException();
        }
    }
}

