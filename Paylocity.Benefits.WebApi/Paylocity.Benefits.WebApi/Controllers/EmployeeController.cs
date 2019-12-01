using Paylocity.Benefits.WebApi.Business.Interfaces;
using Paylocity.Benefits.WebApi.Data.Interfaces;
using Paylocity.Benefits.WebApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Paylocity.Benefits.WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeBLL _employeeBLL;
        private readonly IEmployeeRepository _employeeRepo;

        public EmployeeController(IEmployeeBLL employeeBLL, IEmployeeRepository employeeRepo)
        {
            _employeeBLL = employeeBLL;
            _employeeRepo = employeeRepo;
        }

        [HttpPost]
        public async Task<Employee> CreateEmployeeAsync([FromBody] Employee employee)
        {
            return await _employeeBLL.CreateEmployeeAsync(employee);
        }

        [HttpGet]
        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepo.GetAllEmployeesAsync();
        }
    }
}