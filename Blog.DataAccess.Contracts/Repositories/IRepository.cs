using System;
using System.Linq.Expressions;
using Blog.Model.Entities;

namespace Blog.DataAccess.Contracts
{
    public interface IRepository
    {
        T Get<T, TKey>(TKey id) where T: IEntity<TKey>;
        T Get<T, TKey>(Expression<Func<T, bool>> predicate) where T: IEntity<TKey>;
        void Create<T, TKey>(T entity) where T : IEntity<TKey>;
        void Update<T, TKey>(T entity) where T : IEntity<TKey>;
        void Delete<T, TKey>(T entity) where T : IEntity<TKey>;
    }
}