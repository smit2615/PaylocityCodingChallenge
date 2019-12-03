using Paylocity.Benefits.Model.Interfaces;
using Paylocity.Benefits.Model.Models;
using Paylocity.Benefits.WebApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Benefits.Model.RuleStrategies
{
    public class FirstNameStartsWithLetterARule : IRuleStrategy
    {
        public decimal ApplyRule(Employee employee)
        {
            var costAdjustment = employee.FirstName.ToLower().StartsWith("a") ? employee.BaseBenfitCost : 0;

            foreach(var dependent in employee.Dependents)
            {
                costAdjustment += dependent.FirstName.ToLower().StartsWith("a") ? dependent.BaseBenfitCost : 0;
            }

            return costAdjustment;
        }
    }
}
