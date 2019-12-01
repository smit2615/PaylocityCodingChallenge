using Paylocity.Benefits.Model;
using Paylocity.Benefits.Model.Enums;
using Paylocity.Benefits.Model.Interfaces;
using Paylocity.Benefits.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Benefits.WebApi.Model.Models
{
    public class RuleEngine : IRuleEngine
    {
        private BenefitRule _rule;
        private Employee _employee;
        private decimal _benefitCost;
        private readonly IRuleFactory _ruleFactory;

        public RuleEngine(IRuleFactory ruleFactory)
        {
            _ruleFactory = ruleFactory;
        }

        public void SetRule(BenefitRule rule)
        {
            _rule = rule;
            _rule.Strategy = _ruleFactory.Create((RuleType)rule.BenefitRuleId);
        }

        public void Start(Employee employee)
        {
            _employee = employee;

            _benefitCost = _employee.BenefitCategory.Amount;
            foreach (var dependent in _employee.Dependents)
            {
                _benefitCost += dependent.BenefitCategory.Amount;
            }
        }

        public void ApplyRule()
        {
            var costAdjustment = _rule.Strategy.ApplyRule(_employee) * (_rule.Percentage / 100);
            _benefitCost += _rule.AdjustmentType == AdjustmentType.Discount ? -costAdjustment : costAdjustment;
        }

        public decimal End()
        {
            return _benefitCost;
        }
    }
}
