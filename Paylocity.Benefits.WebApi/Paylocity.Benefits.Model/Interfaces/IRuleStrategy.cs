using Paylocity.Benefits.Model.Enums;
using Paylocity.Benefits.WebApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Benefits.Model.Interfaces
{
    /// <summary>
    /// Contains the logic for applying a BenefitRule to an Employee.
    /// The decimal returned represents the total benefit cost that needs adjusted
    /// based on the application of the rule.
    /// </summary>
    public interface IRuleStrategy
    {
        decimal ApplyRule(Employee employee);
    }
}
