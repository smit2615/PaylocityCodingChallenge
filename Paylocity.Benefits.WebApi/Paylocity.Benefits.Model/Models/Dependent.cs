using Paylocity.Benefits.Model.Enums;
using Paylocity.Benefits.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Benefits.WebApi.Model.Models
{
    public class Dependent : Person
    {
        public int DependentId { get; set; }
        public bool IsSpouse { get; set; }

        public Dependent()
        {
            BenefitCategory = new BenefitCategory()
            {
                BenefitCategoryId = Convert.ToInt32(BenefitType.Dependent)
            };
        }
    }
}
