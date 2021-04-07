using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GBCSporting2021_PepperoniPizza420.DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GBCSporting2021_PepperoniPizza420.DataAccessLayer.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public readonly DbContext Context;
        
        public Repository(DbContext context)
        {
            Context = context;
        }
        public TEntity GetById(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }
        public virtual IEnumerable<TEntity> GetAll(string includeProperties = "")
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

           

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return query;
            
        }
        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }
        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }
        public void Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
        }
        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
