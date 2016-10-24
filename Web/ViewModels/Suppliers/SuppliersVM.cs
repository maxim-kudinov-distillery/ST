using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.ViewModels.Suppliers
{
    public class SuppliersVM
    {
        public Data.Models.Supplier Supplier { get; set; }
        public IEnumerable<Data.Models.Supplier> Suppliers { get; set; }
    }
}