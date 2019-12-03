using Paylocity.Benefits.Model.Enums;
using Paylocity.Benefits.Model.Models;
using Paylocity.Benefits.WebApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Benefits.WebApi.Data.Interfaces
{
    /// <summary>
    /// Creates and supplies data associated with and employee and their information
    /// </summary>
    public interface IEmployeeRepository
    {
        Task<Employee> CreateEmployeeAsync(Employee employee);
        Task<Employee> GetEmployeeByIdAsync(int employeeId);
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<BenefitCategory> GetBenefitCategoryByTypeAsync(BenefitType type);
    }
}
