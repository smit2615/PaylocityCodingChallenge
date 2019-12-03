using Paylocity.Benefits.Model.Enums;
using Paylocity.Benefits.Model.Interfaces;
using Paylocity.Benefits.WebApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Benefits.Model.Models
{
    /// <summary>
    /// Model for storing a benefit rule the adjusts the cost of benefits for an employee.
    /// 
    /// Procedure for rule creation:
    /// 1. Insert a new BenefitRule into BenefitRule table
    /// 2. Add a member to RuleType.cs enum with a backing value that matched the new BenefitRule's ID
    /// 3. Create an implementation for IRuleStrategy that applies your rule's logic
    /// 4. Update RuleFactory.cs to return your implementation when supplied with the RuleType added in step 2
    /// </summary>
    public class BenefitRule
    {
        public int BenefitRuleId { get; set; } // Relates to RuleType enum used for creation in RuleFactory
        public string Description { get; set; } // Rule name or description
        public AdjustmentType AdjustmentType { get; set; } // Discount or upcharge
        public decimal Amount { get; set; } // Amount cost will be adjusted
        public IRuleStrategy Strategy { get; set; } // Rule application logic
    }
}
