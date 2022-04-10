using BenefitsCalculator.Interfaces;
using BenefitsCalculator.Model;
using System;

namespace BenefitsCalculator
{
    public class BenefitsCalculator : IBenefitsCalculator
    {
        double _yearlyBenefitCost;
        double _yearlyDependentCost;
        double _discountForLetterAName;
        int _paychecksPerYear;

        //I don't know what this is included for?  The cost is a flat fee, not a % of wages.
        double _grossPayPerPaycheck;

        public BenefitsCalculator(IBenefitCostService costFinder, IPayrollService payrollService)
        {
            _yearlyBenefitCost = costFinder.GetYearlyBenefitCost();
            _yearlyDependentCost = costFinder.GetYearlyDependentCost();
            _discountForLetterAName = costFinder.GetDiscountForNameStartingWithA();
            _paychecksPerYear = payrollService.GetNumberOfPaychecksPerYear();
            _grossPayPerPaycheck = payrollService.GetGrossDollarAmountPerEmployeePaycheck();
        }

        public double GetBenefitsCostForEmployee(Employee employee)
        {
            double totalCost = 0.0;

            totalCost += (_yearlyBenefitCost / _paychecksPerYear) * GetDiscountFactorForThisPerson(employee);

            if (employee.Dependents != null)
            {
                foreach (Person person in employee.Dependents)
                {
                    totalCost += (_yearlyDependentCost / _paychecksPerYear) * GetDiscountFactorForThisPerson(person);
                }
            }
            return Math.Round(totalCost, 2);
        }

        private double GetDiscountFactorForThisPerson(Person person)
        {
            if (person.Name == null || person.Name.Length < 1)
            {
                return 1;
            }
            else
            {
                //We could additionally engineer this so that the "A" character was injected by some service.
                //But I left it this way for simplicity.
                return person.Name[0].ToString().ToUpper() == "A" ? 1 - _discountForLetterAName : 1;
            }
        }
    }
}
