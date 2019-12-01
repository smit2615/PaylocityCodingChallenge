using Paylocity.Benefits.Model.Enums;
using Paylocity.Benefits.Model.Interfaces;
using Paylocity.Benefits.Model.Models;
using Paylocity.Benefits.Model.RuleStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Benefits.Model
{
    public class RuleFactory : IRuleFactory
    {
        public IRuleStrategy Create(RuleType ruleType)
        {
            switch (ruleType)
            {
                case RuleType.FirstNameStartsWithLetterA:
                    return new FirstNameStartsWithLetterARule();
                default:
                    throw new Exception($"No matching rule found for: {ruleType.ToString()}");
            }
        }
    }
}
