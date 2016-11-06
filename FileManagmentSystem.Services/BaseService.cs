using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using FileManagmentSystem.Models;
using FileManagmentSystem.DataAccess;

namespace FileManagmentSystem.Services
{
    public abstract class BaseService<TEntity>
    where TEntity : BaseEntity, new()
    {
        public BaseRepository<TEntity> Repo { get; set; }

        public BaseService()
        {
        }

        public virtual List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? Repo.GetAll() : Repo.GetAll(filter);
        }

        public virtual List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, int page = 1, int pageSize = 1)
        {

            List<TEntity> result = new List<TEntity>();

            result = Repo.GetAll(filter, page, pageSize);

            return result;
        }

        public virtual int Count(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? Repo.Count() : Repo.Count(filter);
        }

        public virtual void Save(TEntity item)
        {
            Repo.Save(item);
        }

        public virtual void Delete(TEntity itemToDelete)
        {
            Repo.Delete(itemToDelete);
        }

        public virtual TEntity GetById(int id)
        {
            List<TEntity> entities = Repo.GetAll(e => e.Id == id);

            return entities.FirstOrDefault();
        }
    }
}