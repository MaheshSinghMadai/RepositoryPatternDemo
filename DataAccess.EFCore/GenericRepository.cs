using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.EFCore
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        protected ApplicationDbContext _db;

        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        //Get’s the entity By Id.
        T GetById(int id)
        {
            return _db.Set<T>().Find();
        }

        //Get’s all the Record.
        IEnumerable<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        //Finds a set of record that matches the passed expression.
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _db.Set<T>().Where(expression);
        }

        //Adds a new record to the context
        public void Add(T entity)
        {
            _db.Set<T>().Add(entity);
        }

        //Add a list of records
        void AddRange(IEnumerable<T> entities)
        {
            _db.Set<T>().AddRange(entities);
        }

        //Removes a record from the context
        void Remove(T entity)
        {
            _db.Set<T>().Remove(entity);
        }

        //Removes a list of records.
        void RemoveRange(IEnumerable<T> entities)
        {
            _db.Set<T>().RemoveRange(entities);
        }

        T IGenericRepository<T>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IGenericRepository<T>.GetAll()
        {
            throw new NotImplementedException();
        }

        void IGenericRepository<T>.AddRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        void IGenericRepository<T>.Remove(T entity)
        {
            throw new NotImplementedException();
        }

        void IGenericRepository<T>.RemoveRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }
    }
}
