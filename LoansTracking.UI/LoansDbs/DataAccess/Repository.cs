﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoansDbs.DataAccess
{
    public class Repository<Entity> where Entity : class
    {
        public AppContext context;
        public DbSet<Entity> dbSet;

        public Repository(AppContext _context)
        {
            context = _context;
            dbSet = _context.Set<Entity>();
        }
        public AppContext BaseContext()
        {
            return context;
        }
        public IQueryable<Entity> Get()
        {
            return dbSet.AsQueryable();
        }
        public Entity Get(int id)
        {
            return dbSet.Find(id);
        }
        public virtual void Insert(Entity entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }
        public virtual void Update(Entity entity, int id)
        {
            Entity oldEntity = Get(id);
            if(oldEntity != null)
            {
                context.Entry(oldEntity).CurrentValues.SetValues(entity);
                context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            Entity oldEntity = Get(id);
            if(oldEntity != null)
            {
                dbSet.Remove(oldEntity);
                context.SaveChanges();
            }
        }
    }
}
