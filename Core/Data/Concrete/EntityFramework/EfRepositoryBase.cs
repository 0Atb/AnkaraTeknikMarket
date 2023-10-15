using Core.Data.Abstract;
using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Concrete.EntityFramework
{
    public class EfRepositoryBase<Entity, TContext> : IRepository<Entity>
        where Entity : AudiTableEntity, IBaseDomain, new()
        where TContext : DbContext, new()
    {
        public void Delete(Entity entity)
        {
            using (TContext ctx = new TContext())
            {
                ctx.Set<Entity>().Remove(entity);
                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (TContext ctx = new TContext())
            {
                Entity entity = ctx.Set<Entity>().FirstOrDefault(x => x.Id == id);
                ctx.Set<Entity>().Remove(entity);
                ctx.SaveChanges();
            }
        }

        public Entity Get(Expression<Func<Entity, bool>> filter, params string[] includelist)
        {
            using (TContext ctx = new TContext())
            {
                IQueryable<Entity> query = ctx.Set<Entity>();
                if (includelist.Length > 0)
                {
                    foreach (string item in includelist)
                    {
                        query = query.Include(item);
                    }
                }
                return query.SingleOrDefault(filter);
            }
        }

        public List<Entity> GetAll(Expression<Func<Entity, bool>> filter = null, params string[] includelist)
        {
            using (TContext ctx = new TContext())
            {
                IQueryable<Entity> query = ctx.Set<Entity>();
                if (includelist.Length > 0)
                {
                    foreach (string item in includelist)
                    {
                        query = query.Include(item);
                    }
                }
                return filter == null ? query.ToList() : query.Where(filter).ToList();
            }
        }

        public Entity GetById(int id, params string[] includelist)
        {
            using (TContext ctx = new TContext())
            {
                IQueryable<Entity> query = ctx.Set<Entity>();
                if (includelist.Length > 0)
                {
                    foreach (string item in includelist)
                    {
                        query = query.Include(item);
                    }
                }
                return query.SingleOrDefault(x => x.Id == id);
            }
        }

        public void Insert(Entity entity)
        {
            using (TContext ctx = new TContext())
            {
                ctx.Set<Entity>().Add(entity);
                ctx.SaveChanges();
            }
        }

        public void Update(Entity entity)
        {
            using (TContext ctx = new TContext())
            {
                Entity ent = ctx.Set<Entity>().Attach(entity).Entity;
                ctx.Entry(entity).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }
    }
}
