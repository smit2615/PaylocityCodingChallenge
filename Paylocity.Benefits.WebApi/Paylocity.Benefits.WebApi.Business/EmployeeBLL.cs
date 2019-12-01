using Paylocity.Benefits.Model.Enums;
using Paylocity.Benefits.WebApi.Business.Interfaces;
using Paylocity.Benefits.WebApi.Data.Interfaces;
using Paylocity.Benefits.WebApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Benefits.WebApi.Business
{
    public class EmployeeBLL : IEmployeeBLL
    {
        private IBenefitsBLL _benefitsBLL;
        private IEmployeeRepository _employeeRepository;
        private decimal _defaultCompensationRate;

        public EmployeeBLL(IBenefitsBLL benefitsBLL, IEmployeeRepository employeeRepository, decimal defaultCompensationRate)
        {
            _benefitsBLL = benefitsBLL;
            _employeeRepository = employeeRepository;
            _defaultCompensationRate = defaultCompensationRate;
        }

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            if(employee.CompensationRate == default(decimal))
            {
                employee.CompensationRate = _defaultCompensationRate;
            }
            employee.BenefitCategory = await _employeeRepository.GetBenefitCategoryByTypeAsync(BenefitType.Employee);
            var dependentBenefitCategory = await _employeeRepository.GetBenefitCategoryByTypeAsync(BenefitType.Dependent);

            foreach(var dependent in employee.Dependents)
            {
                dependent.BenefitCategory = dependentBenefitCategory;
            }

            await _benefitsBLL.CalculateAnnualCostsAsync(employee);
            return await _employeeRepository.CreateEmployeeAsync(employee);
        }
    }
}
