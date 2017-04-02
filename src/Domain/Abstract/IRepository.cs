using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Abstract
{
    public interface IRepository<TEntity> where TEntity : IEntitie
    {
        TEntity GetById(object id);
        Task<TEntity> GetByIdAsync(int id);

        IQueryable<TEntity> Get();

        Task<int?> GetId(Expression<Func<TEntity, bool>> predicate);


        void Insert(TEntity entity);
        void InsertRange(List<TEntity> entitys);

        void Update(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRange(List<TEntity> entitys);

        Task<bool> Exists(int id);
        Task<bool> Exists(TEntity entity);


        IList<TEntity> GetAll(params Expression<Func<TEntity, object>>[] navigationProperties);
    }
}
