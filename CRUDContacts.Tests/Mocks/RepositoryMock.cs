using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CRUDContacts.Interfaces;
using CRUDContacts.Models;

namespace CRUDContacts.Tests.Mocks
{
    public abstract class RepositoryMock<T> : IRepositoryBase<T> where T : ModelBase
    {
        protected List<T> store = new List<T>();

        public void Add(T model)
        {
            model.Id = store.Count == 0 ? 1 : store.Max(m => m.Id) + 1;
            store.Add(model);
        }

        public void Delete(int id)
        {
            Delete(Read(m => m.Id == id).First());
        }

        public void Delete(T model)
        {
            store.Remove(model);
        }

        public void Edit(T model)
        {
            Delete(model.Id);
            Add(model);
        }

        public bool Exists(int id)
        {
            return store.Any(c => c.Id == id);
        }

        public ICollection<T> Read(Expression<Func<T, bool>> query)
        {
            return store.AsQueryable().Where(query).ToList();
        }

        public ICollection<T> ReadAll()
        {
            return store;
        }

        public void Save() { }
    }
}