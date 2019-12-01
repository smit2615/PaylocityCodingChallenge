using Paylocity.Benefits.WebApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Benefits.WebApi.Business.Interfaces
{
    public interface IBenefitsBLL
    {
        Task CalculateAnnualCostsAsync(Employee employee);
    }
}
