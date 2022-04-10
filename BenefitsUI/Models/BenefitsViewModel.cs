using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitsConsole.Models
{
    public class BenefitsViewModel
    {
        public string EmployeeName { get; set; }

        public List<string> DependentNames { get; set; }

        public double BenefitsCost { get; set; }
    }
}
