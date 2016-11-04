using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SkillsTest.Domain
{
    public abstract class BaseService<C, T> : IBaseService<T>
       where T : class
       where C : DbContext, new()
    {
        private C _entities = new C();
        protected C Context
        {
            get { return _entities; }
            set { _entities = value; }
        }

        public virtual IQueryable<T> All()
        {
            IQueryable<T> query = _entities.Set<T>();
            return query;
        }

        public IQueryable<T> All(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _entities.Set<T>().Where(predicate);
            return query;
        }

        protected virtual void _Add(T entity)
        {
            _entities.Set<T>().Add(entity);
        }

        protected virtual void _Delete(T entity)
        {
            _entities.Set<T>().Remove(entity);
        }

        protected virtual void _Update(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        protected virtual void _SaveChanges()
        {
            _entities.SaveChanges();
        }

        public void Dispose()
        {
            _entities.Dispose();
        }
    }


    public interface IBaseService<T> : IDisposable where T : class
    {
        IQueryable<T> All();
        IQueryable<T> All(Expression<Func<T, bool>> predicate);
    }
}
