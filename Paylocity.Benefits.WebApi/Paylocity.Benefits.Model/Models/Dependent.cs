using Paylocity.Benefits.Model.Enums;
using Paylocity.Benefits.Model.Models;
using Paylocity.Benefits.Model.ViewModels;
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

        public Dependent() : base()
        {
            BenefitCategories.Add(new BenefitCategory()
            {
                BenefitCategoryId = Convert.ToInt32(BenefitType.Dependent)
            });
        }

        public static implicit operator DependentVM(Dependent dependent)
        {
            var dependentVM = new DependentVM()
            {
                DependentId = dependent.DependentId,
                FirstName = dependent.FirstName,
                LastName = dependent.LastName,
                IsSpouse = dependent.IsSpouse
            };

            return dependentVM;
        }
    }
}
