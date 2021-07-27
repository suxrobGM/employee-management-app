using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Models
{
    public class EmployeesViewModel
    {
        [Display(Name = "CSV File"), DataType(DataType.Upload)]
        public IFormFile CsvFile { get; set; }

        public int ProcessedRowsCount { get; set; }

        public IList<Employee> Employees { get; set; }
    }
}