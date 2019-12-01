using Paylocity.Benefits.Model.Enums;
using Paylocity.Benefits.WebApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Benefits.Model.Interfaces
{
    public interface IRuleStrategy
    {
        decimal ApplyRule(Employee employee);
    }
}
