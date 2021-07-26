using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EmployeeManagement.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace EmployeeManagement.Models
{
    public class EmployeesViewModel
    {
        [Display(Name = "CSV File"), DataType(DataType.Upload)]
        public IFormFile CsvFile { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}