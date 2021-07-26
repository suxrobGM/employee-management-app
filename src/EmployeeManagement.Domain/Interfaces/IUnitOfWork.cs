using System;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Interfaces
{
    /// <summary>
    /// Unit of Work pattern
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Get repository
        /// </summary>
        /// <typeparam name="TEntity">Class that implements <see cref="IDomainEntity"/> interface</typeparam>
        /// <returns>Generic repository which implements <typeparamref name="TEntity"/></returns>
        IRepository<TEntity> Repository<TEntity>() where TEntity : class, IDomainEntity;

        /// <summary>
        /// Save changes to database
        /// </summary>
        /// <returns>Number of rows modified after save changes.</returns>
        Task<int> CommitAsync();
    }
}