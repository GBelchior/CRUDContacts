using CRUDContacts.Interfaces;
using CRUDContacts.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CRUDContacts.Core
{
    public class CoreBase<T> where T : ModelBase
    {
        protected IRepositoryBase<T> repository;

        public CoreBase(IRepositoryBase<T> repository)
        {
            this.repository = repository;
        }

        public void Create(T model)
        {
            repository.Add(model);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public void Delete(T model)
        {
            repository.Delete(model);
        }

        public void Edit(T model)
        {
            repository.Edit(model);
        }

        public ICollection<T> Read(Expression<Func<T, bool>> query)
        {
            return repository.Read(query);
        }

        public bool Exists(int id)
        {
            return repository.Exists(id);
        }

        public ICollection<T> ReadAll()
        {
            return repository.ReadAll();
        }

        public void Save()
        {
            repository.Save();
        }
    }
}
