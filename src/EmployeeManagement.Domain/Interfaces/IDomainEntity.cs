namespace EmployeeManagement.Domain.Interfaces
{
    /// <summary>
    /// Interface to define set of entity classes.
    /// </summary>
    /// <remarks>The datatype of the primary key is string</remarks>
    public interface IDomainEntity : IDomainEntityBase
    {
        string Id { get; set; }
    }
}