using Paylocity.Benefits.Model.Models;
using Paylocity.Benefits.WebApi.Data.Contexts;
using Paylocity.Benefits.WebApi.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Benefits.WebApi.Data
{
    public class BenefitRuleRepository : IBenefitRuleRepository
    {
        public async Task<List<BenefitRule>> GetAllRules()
        {
            using(var db = new BenefitsContext())
            {
                return await db.Rules
                    .ToListAsync();
            }
        }
    }
}
