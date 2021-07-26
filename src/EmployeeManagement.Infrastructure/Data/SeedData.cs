using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Infrastructure.Data
{
    /// <summary>
    /// Class that migrates and populates database.
    /// </summary>
    public class SeedData
    {
        public static async void Initialize<TDbContext>(IServiceProvider serviceProvider,
            ILogger logger = null) where TDbContext : DbContext
        {
            try
            {
                var dbContext = serviceProvider.GetRequiredService<TDbContext>();
                await MigrateDatabaseAsync(dbContext, logger);
            }
            catch (Exception ex)
            {
                logger?.LogCritical("Exception thrown in SeedData.Initialize(): {Exception}", ex.Message);
                throw;
            }
        }

        private static async Task MigrateDatabaseAsync<TDbContext>(TDbContext dbContext,
            ILogger logger = null) where TDbContext : DbContext
        {
            try
            {
                await dbContext.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                logger?.LogCritical("Exception thrown in SeedData.MigrateDatabaseAsync(): {Exception}", ex.Message);
                throw;
            }
        }
    }
}