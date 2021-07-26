using System;
using EmployeeManagement.Domain.Interfaces;

namespace EmployeeManagement.Domain.Entities
{
    /// <summary>
    /// Entity model of the personnel.
    /// </summary>
    public class Personnel : IDomainEntity
    {
        public Personnel()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public string PayrollNumber { get; set; }
        public string Forenames { get; set; }
        public string Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Postcode { get; set; }
        public string Email { get; set; }
        public DateTime? StartDate { get; set; }
    }
}