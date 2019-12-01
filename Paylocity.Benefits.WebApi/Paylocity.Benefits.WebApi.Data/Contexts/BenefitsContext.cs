using Paylocity.Benefits.Model.Models;
using Paylocity.Benefits.WebApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Benefits.WebApi.Data.Contexts
{
    public class BenefitsContext : DbContext
    {
        private readonly bool _inMemory;

        public BenefitsContext(bool inMemory = false) : base("BenefitsContext")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Dependent> Dependents { get; set; }
        public virtual DbSet<BenefitRule> Rules { get; set; }
        public virtual DbSet<BenefitCategory> BenefitCategories { get; set; }
    }
}
