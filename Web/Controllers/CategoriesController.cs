using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.ViewModels.Categories;

namespace Web.Controllers
{
    public class CategoriesController : BaseController
    {
        public ActionResult Index(int id = 0)
        {
            var viewModel = new CategoriesVM();

            if (id > 0)
            {
                viewModel.Category = _CategoryBusiness.SelectOneById(id);
            }
            else
            {
                viewModel.Category = new Category();
            }

            viewModel.Categories = _CategoryBusiness.Select().OrderBy(c => c.Name);

            return View(viewModel);
        }

        [HttpPost]
        public JsonResult Save(string nodesString)
        {
            return null;
        }
    }
}