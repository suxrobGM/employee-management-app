using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EmployeeManagement.Domain.Interfaces;
using EmployeeManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class Repository<TEntity>: IRepository<TEntity> where TEntity : class, IDomainEntity
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public TEntity GetById(string id)
        {
            return Get(i => i.Id == id);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null ? _context.Set<TEntity>().ToList() : _context.Set<TEntity>().Where(predicate).ToList();
        }

        public IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate != null ? _context.Set<TEntity>().Where(predicate) : _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            if (id == null)
                return;

            var entity = _context.Set<TEntity>().Find(id);
            Delete(entity);
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
                return;

            _context.Set<TEntity>().Remove(entity);
        }
    }
}