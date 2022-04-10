namespace BenefitsCalculator.Interfaces
{
    public interface IBenefitCostService
    {
        double GetYearlyBenefitCost();
        double GetYearlyDependentCost();
        double GetDiscountForNameStartingWithA();
    }
}
