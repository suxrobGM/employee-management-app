using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using EmployeeManagement.Infrastructure.Maps;
using EmployeeManagement.Infrastructure.Services;
using EmployeeManagement.Models;
using Syncfusion.EJ2.Base;

namespace EmployeeManagement.Controllers
{
    public class EmployeesController : Controller
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Employee> _repository;
        private readonly ICsvService<Employee> _csv;

        #endregion

        #region Ctor

        public EmployeesController(IUnitOfWork unitOfWork, 
            ICsvService<Employee> csv)
        {
            _csv = csv;
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository<Employee>();
        }

        #endregion

        #region Handler methods

        #region Get

        public IActionResult Index()
        {
            var viewModel = new EmployeesViewModel
            {
                Employees = _repository.GetList()
            };
            return View(viewModel);
        }
        
        public IActionResult GetList([FromBody] DataManagerRequest dataManager)
        {
            var dataSource = _repository.GetList();
            return Json(new { result = dataSource, count = dataSource.Count });
        }
        
        public async Task<IActionResult> Update([FromBody] CrudModel<Employee> employeeCrud)
        {
            var employeeEntity = _repository.GetById(employeeCrud.Value.Id);

            if (employeeEntity != null)
            {
                employeeEntity.Forenames = employeeCrud.Value.Forenames;
                employeeEntity.Surname = employeeCrud.Value.Surname;
                _repository.Update(employeeEntity);
                await _unitOfWork.CommitAsync();
            }
            
            return Json(employeeCrud.Value);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion

        #region Post

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImportCsvFile([FromForm] EmployeesViewModel model)
        {
            if (model.CsvFile is null)
            {
                ModelState.AddModelError("CsvFile", "No file uploaded");
                return View("Index", model);
            }
            
            var records = _csv.GetRecords(model.CsvFile.OpenReadStream(), new EmployeeMap());

            foreach (var employeeData in records)
            {
                _repository.Add(employeeData);
            }

            model.ProcessedRowsCount = await _unitOfWork.CommitAsync();
            model.Employees = _repository.GetList();
            return View("Index", model);
        }

        #endregion

        #endregion
    }
}