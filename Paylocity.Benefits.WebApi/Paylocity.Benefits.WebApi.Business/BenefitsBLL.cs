using Paylocity.Benefits.Model;
using Paylocity.Benefits.Model.Enums;
using Paylocity.Benefits.Model.Interfaces;
using Paylocity.Benefits.WebApi.Business.Interfaces;
using Paylocity.Benefits.WebApi.Data.Interfaces;
using Paylocity.Benefits.WebApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Benefits.WebApi.Business
{
    public class BenefitsBLL : IBenefitsBLL
    {
        private readonly IRuleEngine _ruleEngine;
        private readonly IBenefitRuleRepository _ruleRepository;
        private readonly int _numPayPeriods;

        public BenefitsBLL(IRuleEngine ruleEngine, IBenefitRuleRepository ruleRepository, int numPayPeriods)
        {
            _ruleEngine = ruleEngine;
            _ruleRepository = ruleRepository;
            _numPayPeriods = numPayPeriods;
        }
        public async Task CalculateAnnualCostsAsync(Employee employee)
        {
            var rules = await _ruleRepository.GetAllRules();
            _ruleEngine.Start(employee);

            foreach(var rule in rules)
            {
                _ruleEngine.SetRule(rule);
                _ruleEngine.ApplyRule();
            }

            var benefitCost = _ruleEngine.End();
            employee.AnnualSalary = (employee.CompensationRate * _numPayPeriods);
            employee.AnnualCost = employee.AnnualSalary - benefitCost;
        }
    }
}
