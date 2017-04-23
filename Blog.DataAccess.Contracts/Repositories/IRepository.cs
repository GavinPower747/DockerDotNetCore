using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Blog.Model.Entities;

namespace Blog.DataAccess.Contracts.Repositories
{
    public interface IRepository
    {
        T Get<T, TKey>(TKey id) where T: BaseEntity<TKey>;
        IEnumerable<T> Get<T, TKey>(Expression<Func<T, bool>> predicate) where T: BaseEntity<TKey>;
        void Create<T, TKey>(T entity) where T : BaseEntity<TKey>;
        void Update<T, TKey>(T entity) where T : BaseEntity<TKey>;
        void Delete<T, TKey>(T entity) where T : BaseEntity<TKey>;
    }
}