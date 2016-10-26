using Data.Models;

namespace Business.Controllers
{
    class CategoryBusiness: BaseBusiness<Category>
    {
        public CategoryBusiness(DataContext ctx) : base(ctx)
        {

        }
    }
}
