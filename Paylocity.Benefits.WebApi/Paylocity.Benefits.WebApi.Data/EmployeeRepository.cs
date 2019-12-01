using Paylocity.Benefits.Model.Enums;
using Paylocity.Benefits.Model.Models;
using Paylocity.Benefits.WebApi.Data.Contexts;
using Paylocity.Benefits.WebApi.Data.Interfaces;
using Paylocity.Benefits.WebApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Benefits.WebApi.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            using(var db = new BenefitsContext())
            {
                db.Employees.Add(employee);
                await db.SaveChangesAsync();

                return await GetEmployeeByIdAsync(employee.EmployeeId);
            }
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            using(var db = new BenefitsContext())
            {
                return await db.Employees
                    .FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
            }
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            using(var db = new BenefitsContext())
            {
                return await db.Employees
                    .Include(x => x.BenefitCategory)
                    .Include(x => x.Dependents)
                        .Include(x => x.Dependents.Select(y => y.BenefitCategory))
                    .ToListAsync();
            }
        }

        public async Task<BenefitCategory> GetBenefitCategoryByTypeAsync(BenefitType benefitType)
        {
            var benefitCategoryId = Convert.ToInt32(benefitType);
            using (var db = new BenefitsContext())
            {
                return await db.BenefitCategories
                    .FirstOrDefaultAsync(x => x.BenefitCategoryId == benefitCategoryId);
            }
        }
    }
}
