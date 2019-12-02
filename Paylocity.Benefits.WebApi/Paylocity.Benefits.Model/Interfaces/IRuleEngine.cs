using Paylocity.Benefits.Model.Models;
using Paylocity.Benefits.WebApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Benefits.Model.Interfaces
{
    /// <summary>
    /// Responsible for applying the logic to one or more BenefitRule objects
    /// to a given Employee object
    /// </summary>
    public interface IRuleEngine
    {
        void SetRule(BenefitRule rule);
        void ApplyRule();
        void Start(Employee employee);
        decimal End();
    }
}
