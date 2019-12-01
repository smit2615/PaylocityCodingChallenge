using Paylocity.Benefits.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Benefits.Model.Interfaces
{
    public interface IRuleFactory
    {
        IRuleStrategy Create(RuleType ruleType);
    }
}
