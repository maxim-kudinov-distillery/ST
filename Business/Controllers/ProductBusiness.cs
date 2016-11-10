using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Business.Controllers
{
    public class ProductBusiness
    {
        protected readonly DataContext _Ctx;

        public ProductBusiness(DataContext ctx)
        {
            _Ctx = ctx;
        }

        public Product SelectOneById(int id)
        {
            return Select(id).FirstOrDefault();
        }

        public List<Product> Select(int id = 0)
        {
            var selectFrom = _Ctx.Products.Select(a => a);

            var query = selectFrom.Select(a => a);

            if (id > 0)
                query = query.Where(a => a.Id == id);

            return query.ToList();
        }

        public bool Create(Product obj)
        {
            obj.CreatedDate = DateTime.UtcNow;
            return Insert(obj);
        }

        private bool Insert(Product obj)
        {
            _Ctx.Entry(obj).State = EntityState.Added;
            return _Ctx.SaveChanges() > 0;
        }

        public bool Update(Product obj)
        {
            _Ctx.Entry(obj).State = EntityState.Modified;
            return _Ctx.SaveChanges() > 0;
        }

        public bool Delete(Product obj)
        {
            _Ctx.Entry(obj).State = EntityState.Deleted;
            return _Ctx.SaveChanges() > 0;
        }
    }
}

