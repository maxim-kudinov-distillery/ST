using Data.Models;

namespace Business.Controllers
{
    public class ProductBusiness : BaseBusiness<Product>
    {
        public ProductBusiness(DataContext ctx) : base(ctx)
        { 
            
        }
    }
}

