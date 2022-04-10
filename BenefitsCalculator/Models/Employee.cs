using BenefitsCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitsCalculator.Model
{
    public class Employee : Person
    {
        public List<Dependent> Dependents { get; set; }

    }
}
