using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagement.Domain.Interfaces;
using EmployeeManagement.Infrastructure.Data;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class UnitOfWok : IUnitOfWork
    {
        private readonly Dictionary<string, dynamic> _repositories;
        private readonly ApplicationDbContext _context;
        private bool _disposed;

        public UnitOfWok(ApplicationDbContext context)
        {
            _repositories = new Dictionary<string, dynamic>();
            _context = context;
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class, IDomainEntity
        {
            var type = typeof(TEntity).Name;
            if (_repositories.ContainsKey(type))
                return (IRepository<TEntity>)_repositories[type];

            var repositoryType = typeof(Repository<>);
            _repositories.Add(type, Activator.CreateInstance(
                repositoryType.MakeGenericType(typeof(TEntity)), _context)
            );
            return _repositories[type];
        }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    _context.Dispose();
            }
            _disposed = true;
        }
    }
}