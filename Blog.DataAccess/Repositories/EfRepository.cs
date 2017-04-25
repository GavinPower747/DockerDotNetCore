using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Blog.DataAccess.Context;
using Blog.DataAccess.Contracts.Repositories;
using Blog.Model.Entities;

namespace Blog.DataAccess.Repositories
{
    public class EfRepository : IRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EfRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public T Get<T, TKey>(TKey id) where T : BaseEntity<TKey>
        {
            var entities = _dbContext.Set<T>();

            return entities.Find(id);
        }

        public IEnumerable<T> Get<T, TKey>(Expression<Func<T, bool>> predicate) where T : BaseEntity<TKey>
        {
            var entities = _dbContext.Set<T>();
            return entities.Where(predicate);
        }

        public IEnumerable<T> GetAll<T, TKey>() where T : BaseEntity<TKey>
        {
            var entities = _dbContext.Set<T>();
            return entities.AsEnumerable();
        }

        public T Create<T, TKey>(T entity) where T : BaseEntity<TKey>
        {
            ValidateEntity(entity);

            var entities = _dbContext.Set<T>();

            var timestampedEntity = (T)UpdateTimeStamps(entity, true);

            entities.Add(timestampedEntity);
            _dbContext.SaveChanges();

            return timestampedEntity;
        }

        public void Delete<T, TKey>(T entity) where T : BaseEntity<TKey>
        {
            ValidateEntity(entity);
            
            var entities = _dbContext.Set<T>();

            entities.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Update<T, TKey>(T entity) where T : BaseEntity<TKey>
        {
            ValidateEntity(entity);
            UpdateTimeStamps(entity);

            _dbContext.SaveChanges();
        }

        private void ValidateEntity<TKey>(IEntity<TKey> entity)
        {
            if(entity == null)
                throw new ArgumentNullException("Unable to perform operation: Entity cannot be null");
        }

        private IEntity<TKey> UpdateTimeStamps<TKey>(IEntity<TKey> entity, bool isInsert = false)
        {
            var timestampedEntity = entity as ITimeStampedEntity<TKey>;

            if(timestampedEntity == null)
                return entity;

            if(isInsert)
                timestampedEntity.Created = DateTime.UtcNow;
        
            timestampedEntity.LastModified = DateTime.UtcNow;

            return timestampedEntity;
        }
    }
}