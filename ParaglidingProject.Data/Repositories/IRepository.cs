using ParaglidingProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingProject.Data.Repositories
{
    public interface IRepository<TEntity, TKey> where TEntity: IMyEntity
    {
        TEntity GetByID(TKey id);

        IEnumerable<TEntity> GetAll();

        TEntity Insert(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
