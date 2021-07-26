using CsvHelper.Configuration;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Infrastructure.Maps
{
    public sealed class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Map(m => m.PayrollNumber).Name("Personnel_Records.Payroll_Number");
            Map(m => m.Forenames).Name("Personnel_Records.Forenames");
            Map(m => m.Surname).Name("Personnel_Records.Surname");
            
            Map(m => m.Telephone).Name("Personnel_Records.Telephone");
            Map(m => m.Mobile).Name("Personnel_Records.Mobile");
            Map(m => m.Address1).Name("Personnel_Records.Address");
            Map(m => m.Address2).Name("Personnel_Records.Address_2");
            Map(m => m.Postcode).Name("Personnel_Records.Postcode");
            Map(m => m.Email).Name("Personnel_Records.EMail_Home");
            
            Map(m => m.StartDate)
                .Name("Personnel_Records.Start_Date")
                .TypeConverterOption.Format("dd/MM/yyyy", "d/M/yyyy");
            
            Map(m => m.DateOfBirth)
                .Name("Personnel_Records.Date_of_Birth")
                .TypeConverterOption.Format("dd/MM/yyyy", "d/M/yyyy");
        }
    }
}