using Data.Models;
using System.Linq;
using System.Web.Mvc;
using Web.ViewModels;
using Web.ViewModels.Products;

namespace Web.Controllers
{
    public class ProductsController : BaseController
    {

        public ActionResult Index(int id = 0)
        {
            var model = new ProductsVM();


            if(id > 0)
            {
                model.Product = _ProductBusiness.SelectOneById(id);
            }
            else
            {
                model.Product = new Product();
            }

            model.Products = _ProductBusiness.Select().OrderBy(a => a.Name);


            ViewBag.SupplierSelectList = new SelectList(_SupplierBusiness.Select().OrderBy(a => a.Name), "Id", "Name");

            return View(model);
        }


        [HttpPost]
        public JsonResult ProductsSaveData(ProductsVM supplierVm)
        {
            var isEdit = supplierVm.Product.Id > 0;

            var obj = new Product();

            if(isEdit)
                obj = _ProductBusiness.SelectOneById(supplierVm.Product.Id);


            obj.Name = supplierVm.Product.Name;
            obj.SupplierId = supplierVm.Product.SupplierId;


            if(isEdit)
            {
                _ProductBusiness.Update(obj);
            }
            else
            {
                var success = _ProductBusiness.Create(obj);

                if(success)
                    return Json(new DefaultReturnVM() { NewCreatedId = obj.Id });
                else
                    return Json(new DefaultReturnVM() { ValidationError = "Error creating Product" });
            }



            return Json(true);
        }

        [HttpPost]
        public JsonResult ProductDelete(int id)
        {
            if (id ==0)
                return Json(new DefaultReturnVM() { ValidationError = "Error. No Id" });

            var obj = _ProductBusiness.SelectOneById(id);

            if (obj == null)
                return Json(new DefaultReturnVM() { ValidationError = "Error. Obj not found" });



            _ProductBusiness.Delete(obj);

            return Json(true);
        }
        
    }
}
