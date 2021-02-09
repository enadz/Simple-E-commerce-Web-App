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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApShopContext _apShopContext;
        public CategoryRepository(ApShopContext apShopContext )
        {
            _apShopContext = apShopContext;
        }
        public IEnumerable<Category> categories => _apShopContext.categories;
        public Category GetCategoryById(int categoryId) => _apShopContext.categories.FirstOrDefault(p => p.categoryId == categoryId);
        public void AddCategory(Category category) {

            _apShopContext.categories.Add(category);
            _apShopContext.SaveChanges();

        }

       
        public List<Category> GetAllCategories() { List<Category> allCategories = new List<Category>(_apShopContext.categories); return allCategories; }

    }
}
