using Business.Controllers;
using Data.Models;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class BaseController : Controller
    {
        private DataContext _ctx;
        protected DataContext _Ctx
        {
            get { return _ctx ?? (_ctx = new DataContext()); }
        }

        #region Lazy load controllers
        private SupplierBusiness _supplierBusiness;
        public SupplierBusiness _SupplierBusiness
        {
            get { return _supplierBusiness ?? (_supplierBusiness = new SupplierBusiness(_Ctx)); }
        }

        private ProductBusiness _productBusiness;
        public ProductBusiness _ProductBusiness
        {
            get { return _productBusiness ?? (_productBusiness = new ProductBusiness(_Ctx)); }
        }

        private CategoryBusiness _categoryBusiness;
        public CategoryBusiness _CategoryBusiness
        {
            get { return _categoryBusiness ?? (_categoryBusiness = new CategoryBusiness(_Ctx)); }
        }
        #endregion
    }
}
