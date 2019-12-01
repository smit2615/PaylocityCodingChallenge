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
        public BenefitCategory BenefitCategory { get; set; }
    }
}
