using BenefitsCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitsCalculator.Services.Debug
{
    //I guess you might also call this a "Mock"
    public class DebugPayrollService : IPayrollService
    {
        public double GetGrossDollarAmountPerEmployeePaycheck()
        {
            return 2000.0;
        }

        public int GetNumberOfPaychecksPerYear()
        {
            return 26;
        }
    }
}
