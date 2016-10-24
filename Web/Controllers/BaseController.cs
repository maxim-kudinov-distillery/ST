using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Business.Controllers;
using Data.Models;

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
        #endregion

 

    }
}
