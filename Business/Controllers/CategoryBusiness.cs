using Data.Models;
using Data.Models.jsTree;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Business.Controllers
{
    public class CategoryBusiness
    {
        protected readonly DataContext _Ctx;

        public CategoryBusiness(DataContext ctx)
        {
            _Ctx = ctx;
        }

        public Category SelectOneById(int id)
        {
            return Select(id).FirstOrDefault();
        }

        public List<Category> Select(int id = 0)
        {
            var selectFrom = _Ctx.Categories.Select(a => a);

            var query = selectFrom.Select(a => a);

            if (id > 0)
                query = query.Where(a => a.Id == id);

            return query.ToList();
        }

        public bool Create(Category obj)
        {
            obj.CreatedDate = DateTime.UtcNow;
            return Insert(obj);
        }

        private bool Insert(Category obj)
        {
            _Ctx.Entry(obj).State = EntityState.Added;
            return _Ctx.SaveChanges() > 0;
        }

        public bool Update(Category obj)
        {
            _Ctx.Entry(obj).State = EntityState.Modified;
            return _Ctx.SaveChanges() > 0;
        }

        public bool Delete(Category obj)
        {
            _Ctx.Entry(obj).State = EntityState.Deleted;
            return _Ctx.SaveChanges() > 0;
        }

        public bool TrySaveTree(JsTreeModel node, int? parentId)
        {
            int? nodeId = null;

            if (node.Type != "root")
            {
                //jsTree provides unparsable ids for js created nodes (that are not in the DB)
                //so if we can't parse the id then this category should be inserted
                int nodeIdParsed;
                if (!int.TryParse(node.Id, out nodeIdParsed))
                {
                    var createdCategory = _Ctx.Categories.Add(new Category { Name = node.Text, ParentId = parentId, CreatedDate = DateTime.UtcNow });
                    //need to save changes to get new id
                    _Ctx.SaveChanges();
                    nodeId = createdCategory.Id;
                }
                else
                {
                    var dbCategory = SelectOneById(nodeIdParsed);

                    if (dbCategory == null) return false;

                    //the checks below will help us to avoid unnecessary SQL script while saving the changes

                    if (dbCategory.Name != node.Text)
                    {
                        dbCategory.Name = node.Text;
                    }

                    if (dbCategory.ParentId != parentId)
                    {
                        dbCategory.ParentId = parentId;
                    }

                    nodeId = nodeIdParsed;
                }
            }

            if (node.Children != null)
            {
                foreach (var childNode in node.Children)
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
                if (int.TryParse(node.Id, out id))
                {
                    yield return id;
                }

                foreach (var child_id in GetNodesIds(node.Children))
                {
                    yield return child_id;
                }
            }
        }
    }
}
