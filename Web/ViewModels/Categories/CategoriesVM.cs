using Data.Models;
using System.Collections.Generic;

namespace Web.ViewModels.Categories
{
    public class CategoriesVM
    {
        public Category Category { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}