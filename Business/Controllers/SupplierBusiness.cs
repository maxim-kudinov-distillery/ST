using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Data.Models;

namespace Business.Controllers
{
    public class SupplierBusiness
    {
        protected readonly DataContext _Ctx;

        public SupplierBusiness(DataContext ctx)
        {
            _Ctx = ctx;
        }

        public Supplier SelectOneById(int id)
        {
            return Select(id).FirstOrDefault();
        }

        public List<Supplier> Select(int id = 0)
        {
            var selectFrom = _Ctx.Suppliers.Select(a => a);

            var query = selectFrom.Select(a => a);

            if (id > 0)
                query = query.Where(a => a.Id == id);

            return query.ToList();
        }

        public bool Create(Supplier obj)
        {
            obj.CreatedDate = DateTime.UtcNow;
            return Insert(obj);
        }

        private bool Insert(Supplier obj)
        {
            _Ctx.Entry(obj).State = EntityState.Added;
            return _Ctx.SaveChanges() > 0;
        }

        public bool Update(Supplier obj)
        {
            _Ctx.Entry(obj).State = EntityState.Modified;
            return _Ctx.SaveChanges() > 0;
        }

        public bool Delete(Supplier obj)
        {
            _Ctx.Entry(obj).State = EntityState.Deleted;
            return _Ctx.SaveChanges() > 0;
        }
    }
}
