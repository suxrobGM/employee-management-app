using System.Diagnostics;
using System.Linq;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using EmployeeManagement.Infrastructure.Maps;
using EmployeeManagement.Infrastructure.Services;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Employee> _repository;
        private readonly ICsvService<Employee> _csv;
        
        public EmployeesController(IUnitOfWork unitOfWork, 
            ICsvService<Employee> csv)
        {
            _csv = csv;
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository<Employee>();
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
            if (model.CsvFile is null)
            {
                ModelState.AddModelError("CsvFile", "No file uploaded");
                return View("Index", model);
            }
            
            var records = _csv.GetRecords(model.CsvFile.OpenReadStream(), new EmployeeMap());
            return View("Index", model);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}