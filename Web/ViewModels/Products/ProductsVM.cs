using System.Collections.Generic;

namespace Web.ViewModels.Products
{
    public class ProductsVM
    {
        public Data.Models.Product Product { get; set; }
        public IEnumerable<Data.Models.Product> Products { get; set; }
    }
}