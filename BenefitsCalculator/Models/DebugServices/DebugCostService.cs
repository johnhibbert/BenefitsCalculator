using BenefitsCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitsCalculator.Services.Debug
{
    //I guess you might also call this a "Mock"
    public class DebugCostService : IBenefitCostService
    {
        public double GetDiscountForNameStartingWithA()
        {
            return 0.1;
        }

        public double GetYearlyBenefitCost()
        {
            return 1000.0;
        }

        public double GetYearlyDependentCost()
        {
            return 500;
        }
    }
}
