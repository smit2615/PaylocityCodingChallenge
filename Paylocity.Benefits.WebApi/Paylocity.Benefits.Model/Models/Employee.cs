using Paylocity.Benefits.Model.Enums;
using Paylocity.Benefits.Model.Models;
using Paylocity.Benefits.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Benefits.WebApi.Model.Models
{
    public class Employee : Person
    {
        public int EmployeeId { get; set; }
        public IList<Dependent> Dependents { get; set; }
        public decimal CompensationRate { get; set; }
        public decimal AnnualSalary { get; set; }
        public decimal AnnualCost { get; set; }
        public decimal BenefitCost { get; set; }

        public Employee() : base()
        {
            Dependents = new List<Dependent>();
            BenefitCategories.Add(new BenefitCategory()
            {
                BenefitCategoryId = Convert.ToInt32(BenefitType.Employee)
            });
        }

        public static implicit operator EmployeeVM(Employee employee)
        {
            var employeeVM = new EmployeeVM()
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                AnnualCost = employee.AnnualCost,
                BenefitCost = employee.BenefitCost,
                AnnualSalary = employee.AnnualSalary
            };

            foreach(var dependent in employee.Dependents)
            {
                employeeVM.Dependents.Add(dependent);
            }

            return employeeVM;
        }
    }
}
