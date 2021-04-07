using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_PepperoniPizza420.DataAccessLayer.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        
        IEnumerable<TEntity> GetAll(string includeProperties);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);

        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        void Save();
    }
}
