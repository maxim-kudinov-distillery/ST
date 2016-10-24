using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.ViewModels.Products
{
    public class ProductsVM
    {
        public Data.Models.Product Product { get; set; }
        public IEnumerable<Data.Models.Product> Products { get; set; }
    }
}