using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Domain.DbContext;


namespace Domain.Concrete
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntitie
    {
        protected CisDbContext Context { get; }
        protected DbSet<TEntity> DbSet { get; set; }




        public GenericRepository(CisDbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }


        //DEBUG
        public virtual IList<TEntity> GetAll(params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            List<TEntity> list;
           // using (var context = Context)
           // {
                IQueryable<TEntity> dbQuery = Context.Set<TEntity>();

                //Apply eager loading
                foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<TEntity, object>(navigationProperty);

                list = dbQuery
                    .AsNoTracking()
                    .ToList<TEntity>();
          //  }
            return list;
        }



        public virtual TEntity GetById(object id)
        {
            return DbSet.Find(id);
        }


        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }


        public virtual async Task<int?> GetId(Expression<Func<TEntity, bool>> predicate)
        {
           var entity = await DbSet.FirstOrDefaultAsync(predicate);
           return entity?.Id;
        }


        public virtual IQueryable<TEntity> Get()
        {
            return DbSet;
        }



        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }


        public virtual void InsertRange(List<TEntity> entitys)
        {
            for (int i = 0; i < entitys.Count(); i++)
            {
                Insert(entitys[i]);
            }
        }


        public virtual void Update(TEntity entity)
        {
            var local = Context.Set<TEntity>().Local.FirstOrDefault(en => en.Id == entity.Id);
            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }


        public virtual void Remove(TEntity entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            DbSet.Remove(entity);
        }

        public virtual void RemoveRange(List<TEntity> entitys)
        {
            DbSet.RemoveRange(entitys);
        }


        public virtual async Task<bool> Exists(int id)
        {
            return await DbSet.AnyAsync(e=>e.Id == id);
        }


        public virtual async Task<bool> Exists(TEntity entity)
        {
            return await DbSet.AnyAsync(e => e.Id == entity.Id);
        }
    }
}