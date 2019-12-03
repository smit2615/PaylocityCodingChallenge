using Paylocity.Benefits.WebApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Benefits.Model.Models
{
    public class BenefitCategory
    {
        public int BenefitCategoryId { get; set; }
        public decimal Amount { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Dependent> Dependents { get; set; }
    }
}
