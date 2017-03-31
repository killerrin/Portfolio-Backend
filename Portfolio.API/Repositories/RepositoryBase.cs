﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.API.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected readonly PortfolioContext _context;
        protected DbSet<T> _dbSet;

        public int Count => GetAll().ToList().Count;

        public RepositoryBase(PortfolioContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual void Add(T item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public virtual bool Exists(int key)
        {
            return Find(key) != null;
        }

        public virtual T Find(int key)
        {
            return _dbSet.Find(key);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        public virtual void Remove(int key)
        {
            var entity = Find(key);

            if (_context.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);

            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public virtual void Update(T item)
        {
            _dbSet.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual void Commit()
        {
            _context.SaveChanges();
        }
        public virtual void Dispose()
        {
            _context.Dispose();
        }
    }
}