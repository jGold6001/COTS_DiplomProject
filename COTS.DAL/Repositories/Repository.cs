using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity.Migrations;
using COTS.DAL.Interfaces;

namespace COTS.DAL.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext context;
        protected IDbSet<T> dbSet;
        public Repository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
        public void AddOrUpdate(T entity)
        {
            dbSet.AddOrUpdate(entity);           
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet;
        }
    }
}
