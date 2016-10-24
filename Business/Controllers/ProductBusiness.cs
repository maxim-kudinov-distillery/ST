using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Data.Models;

namespace Business.Controllers
{
    public class ProductBusiness
    {
        private DataContext _Ctx;

        #region Constructor
        public ProductBusiness(DataContext ctx)
        {
            _Ctx = ctx;
        }
        #endregion


        #region Select methods
        public Product SelectOneById(int id)
        {
            return Select(id: id).FirstOrDefault();
        }


        public List<Product> Select(int id = 0)
        {
            var selectFrom = _Ctx.Products.Select(a => a);

            var query = selectFrom.Select(a => a);

            if(id > 0)
                query = query.Where(a => a.ProductId == id);


            return query.ToList();
        }
        #endregion






        #region Insert methods
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
        #endregion


        #region Update methods
        public bool Update(Product obj)
        {
            _Ctx.Entry(obj).State = EntityState.Modified;
            return _Ctx.SaveChanges() > 0;
        }
        #endregion


        #region Delete methods
        public bool Delete(Product obj)
        {
            _Ctx.Entry(obj).State = EntityState.Deleted;
            return _Ctx.SaveChanges() > 0;
        }
        #endregion
    }
}
