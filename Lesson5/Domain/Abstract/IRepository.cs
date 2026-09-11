using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Lesson5.Domain.Abstract
{
    public interface IRepository<T>
    {
        T? Get(Expression<Func<T, bool>> exp);
        T? Get(int id);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> exp);
        IEnumerable<T> GetAll();
        T? Add(T obj);
        T? Update(T obj);
        bool Delete(T obj);
        bool SaveChanges();
    }
}
