using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Forms.DA;
using Forms.Models;
using Forms.Repositories.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Forms.Repositories.Commun
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : BaseModel
    {
        protected FormsContext DbCxt;
        protected DbSet<TEntity> DbSet;

        public GenericRepository(FormsContext context)
        {
            DbCxt = context;
            DbSet = context.Set<TEntity>();
        }

        public void Delete(object id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            this.Delete(entityToDelete);
        }

        public void Delete(TEntity entityToDelete)
        {
            if (DbCxt.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }

            DbSet.Remove(entityToDelete);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if(orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public TEntity GetByID(object id)
        {
            return DbSet.Find(id);
        }

        public long Insert(TEntity entity)
        {
            DbSet.Add(entity);
            return entity.Id;
        }

        public void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            DbCxt.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public void UpdateAll(IEnumerable<TEntity> entitiesToUpdate)
        {
            foreach (var entity in entitiesToUpdate)
            {
                this.Update(entity);
            }
        }
    }
}
