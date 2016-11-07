using Data.Models;
using System.Collections.Generic;
using Web.ViewModels.Categories;

namespace Web.ViewModels.Products
{
    public class ProductsVM: TreeVM
    {
        public Product Product { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}