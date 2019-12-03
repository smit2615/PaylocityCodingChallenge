using Paylocity.Benefits.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Benefits.WebApi.Model.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<BenefitCategory> BenefitCategories { get; set; } = new List<BenefitCategory>();

        /// <summary>
        /// Calculates benefit cost before any rules are applied to this Person
        /// </summary>
        /// <returns></returns>
        public decimal BaseBenfitCost
        {
            get
            {
                decimal total = 0;
                foreach(var benefit in BenefitCategories)
                {
                    total += benefit.Amount;
                }

                return total;
            }
        }
    }
}
