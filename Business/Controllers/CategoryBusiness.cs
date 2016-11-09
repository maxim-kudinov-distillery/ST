using Data.Models;
using Data.Models.jsTree;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Controllers
{
    public class CategoryBusiness : BaseBusiness<Category>
    {
        public CategoryBusiness(DataContext ctx) : base(ctx)
        {

        }

        public bool TrySaveTree(JsTreeModel node, int? parentId)
        {
            int? nodeId = null;

            if (node.type != "root")
            {
                //jsTree provides unparsable ids for js created nodes (that are not in the DB)
                //so if we can't parse the id then this category should be inserted
                int nodeIdParsed;
                if (!int.TryParse(node.id, out nodeIdParsed))
                {
                    var createdCategory = _Ctx.Categories.Add(new Category { Name = node.text, ParentId = parentId, CreatedDate = DateTime.UtcNow });
                    //need to save changes to get new id
                    _Ctx.SaveChanges();
                    nodeId = createdCategory.Id;
                }
                else
                {
                    var dbCategory = SelectOneById(nodeIdParsed);

                    if (dbCategory == null) return false;

                    //the checks below will help us to avoid unnecessary SQL script while saving the changes

                    if (dbCategory.Name != node.text)
                    {
                        dbCategory.Name = node.text;
                    }

                    if (dbCategory.ParentId != parentId)
                    {
                        dbCategory.ParentId = parentId;
                    }

                    nodeId = nodeIdParsed;
                }
            }

            if (node.children != null)
            {
                foreach (var childNode in node.children)
                {
                    if (!TrySaveTree(childNode, nodeId)) return false;
                }
            }

            return true;
        }

        public bool TryDeleteNodes(ICollection<JsTreeModel> nodes)
        {
            var categoriesIds = _Ctx.Categories.Select(c => c.Id);
            var nodesIds = new HashSet<int>(GetNodesIds(nodes));
            var nodesToDelete = categoriesIds.Except(nodesIds);

            _Ctx.Categories.RemoveRange(_Ctx.Categories.Where(c => nodesToDelete.Any(n=>n == c.Id)));

            return true;
        }

        private IEnumerable<int> GetNodesIds(ICollection<JsTreeModel> nodes)
        {
            if (nodes == null) yield break;

            foreach (var node in nodes)
            {
                int id = 0;
                if (int.TryParse(node.id, out id))
                {
                    yield return id;
                }

                foreach (var child_id in GetNodesIds(node.children))
                {
                    yield return child_id;
                }
            }
        }
    }
}
