using BenefitsCalculator.Model;

namespace BenefitsCalculator.Interfaces
{
    public interface IBenefitsCalculator
    {
        double GetBenefitsCostForEmployee(Employee employee);
    }
}