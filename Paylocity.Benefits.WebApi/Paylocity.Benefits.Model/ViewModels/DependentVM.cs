using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Benefits.Model.ViewModels
{
    public class DependentVM : PersonVM
    {
        public int DependentId { get; set; }
        public bool IsSpouse { get; set; }
    }
}
