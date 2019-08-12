using DesignPatterns.Data.IBase;
using DesignPatterns.Data.IRespositories;
using DesignPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DesignPatterns.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity ,new ()
    {
        private ApplicationContext _Context ;
        #region("Constructor")
        public Repository(ApplicationContext context)
        {
            _Context = context;
        }
        #endregion
        #region("Interface implementation")
        public void Add(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            _Context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
        }

        public bool Any(Expression<Func<T, bool>> filter)
        {
            return _Context.Set<T>().Any(filter);
        }

        public int Count(Expression<Func<T, bool>> filter)
        {
             return _Context.Set<T>().Count(filter);
        }

        public void Delete(int id)
        {
            var entity = new T () { Id = id };
            _Context.Entry(entity);
            _Context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public T Find(int id)
        {
            return _Context.Set<T>().Find(id);
        }
        public void Update(T entity)
        {
            _Context.Entry(entity);
            _Context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        public ICollection<T> Find(FilterOptions<T> filter)
        {
            var orderByClass = GetOrderBy(filter);
            Expression<Func<T, bool>> whereTrue = x => true;
            var where = (filter.Where == null) ? whereTrue : filter.Where;
            
            if (orderByClass.IsAscending)
            {
                return _Context.Set<T>().Where(where).OrderBy(orderByClass.OrderBy)
                .Skip((filter.Page - 1) * filter.Top)
                .Take(filter.Top).ToList();
            }
            else
            {
                return _Context.Set<T>().Where(where).OrderByDescending(orderByClass.OrderBy)
                .Skip((filter.Page - 1) * filter.Top)
                .Take(filter.Top).ToList();
            }

        }
        #endregion
        private OrderByClass GetOrderBy(FilterOptions<T> filter)
        {
            if (filter.OrderBy == null && filter.OrderByDescending == null)
            {
                return new OrderByClass(x => x.Id, true);
            }

            return (filter.OrderBy != null)
                ? new OrderByClass(filter.OrderBy, true) :
                new OrderByClass(filter.OrderByDescending, false);
        }
        #region("Private class to order by *")
        private class OrderByClass
        {
            public OrderByClass()
            {

            }

            public OrderByClass(Func<T, object> orderBy, bool isAscending)
            {
                OrderBy = orderBy;
                IsAscending = isAscending;
            }

            public Func<T, object> OrderBy { get; set; }
            public bool IsAscending { get; set; }
        }
        #endregion
    }
}
