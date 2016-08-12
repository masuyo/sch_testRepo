using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.GenericRepos
{
    public abstract class GenericEFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext context;

        public GenericEFRepository(DbContext newctx)
        {
            context = newctx;
        }

        public virtual void Insert(TEntity newentity)
        {
            //TEntityket beállító halmazt adja vissza, majd az Add hozzáadja az új elemet
            //Lazy loading
            context.Set<TEntity>().Add(newentity);
            context.Entry<TEntity>(newentity).State = EntityState.Added;
            context.SaveChanges();
        }

        //törlés
        public void Delete(TEntity entityToDelete)
        {
            context.Set<TEntity>().Remove(entityToDelete); //adott típus tároló tábla keresése, onnan eltávolítás
            context.Entry<TEntity>(entityToDelete).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            TEntity entityToDelete = GetById(id);
            if (entityToDelete == null)
            {
                throw new ArgumentException("NO DATA");
            }
            Delete(entityToDelete);
        }

        public abstract TEntity GetById(int id);

        //felszólítás
        public void Dispose()
        {
            context.Dispose();
        }

        //szűrés szűrőfeltétel alapján
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return GetAll().Where(filter);
        }

        //lekérés
        public IQueryable<TEntity> GetAll()
        {
            return context.Set<TEntity>();
        }
    }
}
