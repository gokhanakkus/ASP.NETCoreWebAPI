using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Abstract
{
    public interface IRepository<T> where T : class, new()
    {
        T GetById(int id);
        List<T> Get(Expression<Func<T, bool>>? filter = null);
        T Create(T entity);
        T Update(int id, T entity);
        bool Delete(int id);
    }
}
