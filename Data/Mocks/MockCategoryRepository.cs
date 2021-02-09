using apshop.Data.Models;
using apshop.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apshop.Data.Mocks
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> categories
        {
            get
            {
                return new List<Category>
                     {
                         new Category { categoryId = 101, name = "Toys", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit", subcategoryId=102},
                         new Category { categoryId = 201, name = "Clothes", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit" , subcategoryId=202},
                          new Category { categoryId = 202, name = "Footwear", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit" },
                         new Category { categoryId = 102, name = "Plush Toys", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit" },
                     };
            }
        }

       
        public void AddCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryById(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}