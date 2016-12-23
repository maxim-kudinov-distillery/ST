using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Business.Controllers
{
    public abstract class BaseBusiness<T> where T : BaseEntity
    {
        protected readonly DataContext _Ctx;

        public BaseBusiness(DataContext ctx)
        {
            _Ctx = ctx;
        }

        public T SelectOneById(int id)
        {
            return Select(id: id).FirstOrDefault();
        }

        public List<T> Select(int id = 0)
        {
            var selectFrom = _Ctx.Set<T>().Select<T,T>(a => a);

            var query = selectFrom.Select(a => a);

            if (id > 0)
                query = query.Where<T>(a => a.Id == id);

            return query.ToList<T>();
        }

        public bool Create(T obj)
        {
            obj.CreatedDate = DateTime.UtcNow;
            return Insert(obj);
        }

        private bool Insert(T obj)
        {
            _Ctx.Entry(obj).State = EntityState.Added;
            return _Ctx.SaveChanges() > 0;
        }

        public bool Update(T obj)
        {
            _Ctx.Entry(obj).State = EntityState.Modified;
            return _Ctx.SaveChanges() > 0;
        }

        public bool Delete(T obj)
        {
            _Ctx.Entry(obj).State = EntityState.Deleted;
            return _Ctx.SaveChanges() > 0;
        }
    }
}
