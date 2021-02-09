using apshop.Data.Models;
using apshop.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apshop.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController
    {
        private readonly ICategoryRepository _categoryRepository;

            public CategoryController(ICategoryRepository categoryRepository)
            {
                _categoryRepository = categoryRepository;

            }
        
        [HttpPost]
        public Category NewCategory([FromBody]Category category)
        {

            _categoryRepository.AddCategory(category);
            return category;

        }

        [HttpGet("all")]
        public List<Category> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }

        [HttpGet("{categoryId}")]
        public Category GetCategoryById(int categoryId)
        {
            return _categoryRepository.GetCategoryById(categoryId);
        }

    }
}
