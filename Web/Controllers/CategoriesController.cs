using Data.Models;
using Data.Models.jsTree;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
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
        public JsonResult Save(IList<JsTreeModel> nodes)
        {
            if (_CategoryBusiness.TryDeleteNodes(nodes)) 
            {
                if (nodes.Count == 1 && _CategoryBusiness.TrySaveTree(nodes[0], null))
                {
                    _Ctx.SaveChanges();
                    return Json(string.Empty);
                }
            }

            return null;
        }
    }
}