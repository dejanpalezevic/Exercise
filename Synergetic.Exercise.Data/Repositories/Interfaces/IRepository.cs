using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synergetic.Exercise.Data.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T entity);

        void Add<T>(T entity) where T : class;

        void Delete(T entity);

        void Delete<T>(T entity) where T : class;

        T Get(int id);

        T Get<T>(params object[] keyValues) where T : class;

        IQueryable<T> FindAll();

        IQueryable<T> FindAll<T>() where T : class;

        void SaveChanges();
    }
}
