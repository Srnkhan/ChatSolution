using ChatModals.DbModal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatDb.Repository
{
    public class EFRepository<T> : IRepository<T> where T : ModalBase
    {
        private readonly MainDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public EFRepository(MainDbContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<T>();
        }
        public void Add(T entity)
        {
            entity.Id = Guid.NewGuid();
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);
            Delete(entity);
        }

        public T Get(Func<T, bool> predicate)
        {
            return _dbSet.Where(predicate)?.FirstOrDefault();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public IQueryable<T> GetAll(Func<T, bool> predicate)
        {
            return (IQueryable<T>)_dbSet.AsQueryable();
        }

        public T GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            _dbContext.Update(entity);
        }
    }
}
