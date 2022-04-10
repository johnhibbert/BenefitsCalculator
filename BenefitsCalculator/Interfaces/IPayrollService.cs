using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitsCalculator.Interfaces
{
    public interface IPayrollService
    {
        int GetNumberOfPaychecksPerYear();
        double GetGrossDollarAmountPerEmployeePaycheck();

    }
}
