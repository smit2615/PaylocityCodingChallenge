using Paylocity.Benefits.Model.Models;
using Paylocity.Benefits.WebApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Benefits.Model.Interfaces
{
    public interface IRuleEngine
    {
        void SetRule(BenefitRule rule);
        void ApplyRule();
        void Start(Employee employee);
        decimal End();
    }
}
