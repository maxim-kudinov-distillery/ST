using Data.Models;

namespace Business.Controllers
{
    public class CategoryBusiness: BaseBusiness<Category>
    {
        public CategoryBusiness(DataContext ctx) : base(ctx)
        {

        }
    }
}
