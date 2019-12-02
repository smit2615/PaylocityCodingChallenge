using Paylocity.Benefits.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Benefits.WebApi.Data.Interfaces
{
    /// <summary>
    /// Supplies the current list of rules in the benefits system
    /// </summary>
    public interface IBenefitRuleRepository
    {
        Task<List<BenefitRule>> GetAllRules();  
    }
}
