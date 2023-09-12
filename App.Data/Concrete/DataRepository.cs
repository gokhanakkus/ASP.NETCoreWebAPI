using App.Data.Abstract;
using App.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Concrete
{
    public class DataRepository<T> : IRepository<T> where T : class, new()
    {
        AppDbContext _context;

        public DataRepository(AppDbContext context)
        {
            _context = context;
        }


        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var entity = _context.Set<T>().Find(id);

            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
                return true;
            }
            return false;

        }

        public List<T> Get(Expression<Func<T, bool>>? filter = null)
        {
            return filter == null
                ? _context.Set<T>().ToList()
                : _context.Set<T>().Where(filter).ToList();
        }


        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }


        public T Update(int id, T entity)
        {
            var entityToUpdate = _context.Set<T>().Find(id);

            if (entityToUpdate != null)
            {
                _context.Set<T>().Entry(entityToUpdate).CurrentValues.SetValues(entity);
                _context.SaveChanges();

            }
            return entityToUpdate;
        }
    }
}
