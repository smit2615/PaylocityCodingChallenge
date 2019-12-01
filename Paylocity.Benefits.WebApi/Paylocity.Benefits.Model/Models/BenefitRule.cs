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
    public class BenefitRule
    {
        public int BenefitRuleId { get; set; }
        public string Description { get; set; }
        public AdjustmentType AdjustmentType { get; set; }
        public decimal Percentage { get; set; }
        public IRuleStrategy Strategy { get; set; }
    }
}
