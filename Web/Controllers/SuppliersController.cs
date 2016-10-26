using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Data.Models;
using Web.ViewModels;
using Web.ViewModels.Suppliers;

namespace Web.Controllers
{
    public class SuppliersController : BaseController
    {

        public ActionResult Index(int id = 0)
        {
            var model = new SuppliersVM();


            if(id > 0)
            {
                model.Supplier = _SupplierBusiness.SelectOneById(id);
            }
            else
            {
                model.Supplier = new Supplier();
            }

            model.Suppliers = _SupplierBusiness.Select().OrderBy(a => a.Name);


            return View(model);
        }


        [HttpPost]
        public JsonResult SuppliersSaveData(SuppliersVM supplierVm)
        {
            var isEdit = supplierVm.Supplier.Id > 0;

            var obj = new Supplier();

            if(isEdit)
                obj = _SupplierBusiness.SelectOneById(supplierVm.Supplier.Id);


            obj.Name = supplierVm.Supplier.Name;
            


            if(isEdit)
            {
                _SupplierBusiness.Update(obj);
            }
            else
            {
                var success = _SupplierBusiness.Create(obj);

                if(success)
                    return Json(new DefaultReturnVM() { NewCreatedId = obj.Id });
                else
                    return Json(new DefaultReturnVM() { ValidationError = "Error creating Supplier" });
            }



            return Json(true);
        }

        [HttpPost]
        public JsonResult SupplierDelete(int id)
        {
            if (id ==0)
                return Json(new DefaultReturnVM() { ValidationError = "Error. No Id" });

            var obj = _SupplierBusiness.SelectOneById(id);

            if (obj == null)
                return Json(new DefaultReturnVM() { ValidationError = "Error. Obj not found" });



            _SupplierBusiness.Delete(obj);

            return Json(true);
        }
        
    }
}
