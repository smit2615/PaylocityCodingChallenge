using Paylocity.Benefits.Model.Enums;
using Paylocity.Benefits.Model.Models;
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
        public decimal AnnualCost { get; set; }

        public Employee()
        {
            Dependents = new List<Dependent>();
            BenefitCategory = new BenefitCategory()
            {
                BenefitCategoryId = Convert.ToInt32(BenefitType.Employee)
            };
        }
    }
}
