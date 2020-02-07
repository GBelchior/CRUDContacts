using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CRUDContacts.Models;

namespace CRUDContacts.Interfaces
{
    public interface IRepositoryBase<T> where T : ModelBase
    {
        ICollection<T> Read(Expression<Func<T, bool>> query);
        ICollection<T> ReadAll();

        bool Exists(int id);
        void Add(T model);
        void Edit(T model);
        void Delete(int id);
        void Delete(T model);
        void Save();
    }
}