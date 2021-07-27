using EmployeeManagement.Infrastructure.Data;
using Xunit;

namespace EmployeeManagement.UnitTests
{
    public class DbContextTests
    {
        private readonly ApplicationDbContext _context;
        
        public DbContextTests()
        {
            _context = new ApplicationDbContext();
        }
        
        [Fact]
        public async void CheckConnection()
        {
            var available = await _context.Database.CanConnectAsync();
            Assert.True(available);
        }
    }
}