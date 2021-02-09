using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apshop.Data.Models
{
    public class Category
    { 
        public int categoryId { get; set; }
        public int subcategoryId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public ICollection<Item> items { get; set; }
        public ICollection<Category> subcategories { get; set; }

    }
}