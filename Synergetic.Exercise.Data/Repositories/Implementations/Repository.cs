using Synergetic.Exercise.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synergetic.Exercise.Data.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        public Repository(DbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            Add<T>(entity);
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            Delete<T>(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Set<T>().Remove(entity);
        }

        public T Get(int id)
        {
            return Get<T>(id);
        }


        public T Get<T>(params object[] keyValues) where T : class
        {
            return _context.Set<T>().Find(keyValues);
        }

        public IQueryable<T> FindAll()
        {
            return FindAll<T>();
        }

        public IQueryable<T> FindAll<T>() where T : class
        {
            return _context.Set<T>();
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
