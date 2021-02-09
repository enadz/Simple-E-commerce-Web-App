using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apshop.Data.Models;

namespace apshop.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> categories { get; }
        Category GetCategoryById(int categoryId);
        public List<Category> GetAllCategories();
        public void AddCategory(Category category);

    }
}
