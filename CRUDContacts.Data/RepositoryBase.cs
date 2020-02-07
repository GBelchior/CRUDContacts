using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CRUDContacts.Interfaces;
using CRUDContacts.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDContacts.Data
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : ModelBase
    {
        protected CRUDContactsContext context;
        protected DbSet<T> dbSet;

        public RepositoryBase(CRUDContactsContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public void Add(T model)
        {
            dbSet.Add(model);
        }

        public void Delete(int id)
        {
            Delete(dbSet.Find(id));
        }
        
        public void Delete(T model)
        {
            dbSet.Remove(model);
        }

        public void Edit(T model)
        {
            context.Entry(model).State = EntityState.Modified;
        }

        public bool Exists(int id)
        {
            return dbSet.Any(m => m.Id == id);
        }

        public ICollection<T> Read(Expression<Func<T, bool>> query)
        {
            return dbSet.Where(query).ToList();
        }

        public ICollection<T> ReadAll()
        {
            return dbSet.ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}