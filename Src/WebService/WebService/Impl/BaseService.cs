using EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Impl
{
    public abstract class BaseService<T> : IBaseService<T> where T : class
    {
        protected BlogDbContext DbContext { get; set; }

        protected BaseService(BlogDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public IQueryable<T> FindAll()
        {
            return DbContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return DbContext.Set<T>().Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            DbContext.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            DbContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
        }
    }
}
