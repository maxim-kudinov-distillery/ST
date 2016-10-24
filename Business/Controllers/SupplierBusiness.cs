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
        private DataContext _Ctx;

        #region Constructor
        public SupplierBusiness(DataContext ctx)
        {
            _Ctx = ctx;
        }
        #endregion


        #region Select methods
        public Supplier SelectOneById(int id)
        {
            return Select(id: id).FirstOrDefault();
        }


        public List<Supplier> Select(int id = 0)
        {
            var selectFrom = _Ctx.Suppliers.Select(a => a);

            var query = selectFrom.Select(a => a);

            if(id > 0)
                query = query.Where(a => a.SupplierId == id);


            return query.ToList();
        }
        #endregion






        #region Insert methods
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
        #endregion


        #region Update methods
        public bool Update(Supplier obj)
        {
            _Ctx.Entry(obj).State = EntityState.Modified;
            return _Ctx.SaveChanges() > 0;
        }
        #endregion


        #region Delete methods
        public bool Delete(Supplier obj)
        {
            _Ctx.Entry(obj).State = EntityState.Deleted;
            return _Ctx.SaveChanges() > 0;
        }
        #endregion
    }
}
