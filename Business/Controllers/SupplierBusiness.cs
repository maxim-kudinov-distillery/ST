using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Data.Models;

namespace Business.Controllers
{
    public class SupplierBusiness: BaseBusiness<Supplier>
    {
        public SupplierBusiness (DataContext ctx) : base(ctx)
        {

        }
    }
}
