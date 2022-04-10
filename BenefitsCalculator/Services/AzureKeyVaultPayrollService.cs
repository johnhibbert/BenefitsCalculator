using BenefitsCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitsCalculator.Services
{
    public class AzureKeyVaultPayrollService : IPayrollService
    {
        // FAKE TODO: Make this real.
        public double GetGrossDollarAmountPerEmployeePaycheck()
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfPaychecksPerYear()
        {
            throw new NotImplementedException();
        }
    }
}
