using Paylocity.Benefits.WebApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Benefits.Model.ViewModels
{
    public class EmployeeVM : PersonVM
    {
        public int EmployeeId { get; set; }
        public IList<DependentVM> Dependents { get; set; } = new List<DependentVM>();
        public decimal AnnualCost { get; set; }
        public decimal BenefitCost { get; set; }
        public decimal AnnualSalary { get; set; }
    }
}
