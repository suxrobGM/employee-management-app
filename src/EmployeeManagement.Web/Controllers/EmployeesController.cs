using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using EmployeeManagement.Infrastructure.Services;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IRepository<Employee> _repository;
        private readonly ICsvService<Employee> _csv;
        
        public EmployeesController(IRepository<Employee> repository, 
            ICsvService<Employee> csv)
        {
            _repository = repository;
            _csv = csv;
        }
        
        public IActionResult Index()
        {
            var viewModel = new EmployeesViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ImportCsvFile([FromForm] EmployeesViewModel model)
        {
            
            return View("Index", model);
        }
    }
}