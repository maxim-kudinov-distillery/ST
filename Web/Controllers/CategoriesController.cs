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
        public JsonResult Save(string treeJson, string nodesToDeleteJson)
        {
            var jsSerializer = new JavaScriptSerializer();
            var tree = jsSerializer.Deserialize<List<JsTreeModel>>(treeJson);
            if (_CategoryBusiness.TrySaveTree(tree[0], null))
            {
                var nodesToDelete = jsSerializer.Deserialize<List<NodeModel>>(nodesToDeleteJson);
                if (_CategoryBusiness.TryDeleteNodes(nodesToDelete))
                {
                    _Ctx.SaveChanges();
                    return Json(string.Empty);
                }
            }

            return null;
        }
    }
}