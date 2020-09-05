using System.Collections.Generic;
using System.Linq;
using Edu.data.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Edu.data.Concrete.EfCore
{
    public class EfCoreGenericRepository<TEntity, TContext> : IRepository<TEntity>
    where TEntity: class
    where TContext: DbContext, new()
    {
        public bool Create(TEntity entity)
        {
            using(var context = new TContext())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
                return true;
            }
        }

        // public bool Delete(TEntity entity)
        // {
        //     using(var context = new TContext())
        //     {
        //         context.Set<TEntity>().Remove(entity);
        //         context.SaveChanges();
        //         return true;
        //     }
        // }

        // public List<TEntity> GetAll()
        // {
        //     using(var context = new TContext())
        //     {
        //         return context.Set<TEntity>().ToList();
        //     }
        // }

        // public TEntity GetById(int id)
        // {
        //     using(var context = new TContext())
        //     {
        //         return context.Set<TEntity>().Find(id);
        //     }
        // }
        public bool Update(TEntity entity)
        {
            using(var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }
    }
}