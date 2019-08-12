using DesignPatterns.Data.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DesignPatterns.Data.IRespositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Delete(int id);
        void Update(T entity);
        T Find(int id);
        ICollection<T> Find(FilterOptions<T> filter);
        int Count(Expression<Func<T, bool>> filter);
        bool Any(Expression<Func<T, bool>> filter);
    }
}
