using BenefitsCalculator.Model;
using BenefitsCalculator.Services.Debug;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Xml.Linq;

namespace BenefitsCalculator.Tests
{
    [TestClass]
    public class BenefitsCalculatorTests
    {
        [TestMethod]
        public void EmployeeA_NoDependents()
        {
            var april = new Employee()
            {
                Name = "April",
                Dependents = new List<Dependent>(),
            };

            BenefitsCalculator sut = new BenefitsCalculator(new DebugCostService(), new DebugPayrollService());

            var result = sut.GetBenefitsCostForEmployee(april);

            Assert.AreEqual(34.62, result);
        }

        [TestMethod]
        public void EmployeeNonA_NoDependents()
        {
            var bob = new Employee()
            {
                Name = "Bob",
                Dependents = new List<Dependent>(),
            };

            BenefitsCalculator sut = new BenefitsCalculator(new DebugCostService(), new DebugPayrollService());

            var result = sut.GetBenefitsCostForEmployee(bob);

            Assert.AreEqual(38.46, result);
        }

        [TestMethod]
        public void EmployeeNonA_DependentNonA()
        {
            var carmen = new Employee()
            {
                Name = "Carmen",
                Dependents = new List<Dependent>() 
                {
                    new Dependent(){Name = "David" }
                },
            };

            BenefitsCalculator sut = new BenefitsCalculator(new DebugCostService(), new DebugPayrollService());

            var result = sut.GetBenefitsCostForEmployee(carmen);

            Assert.AreEqual(57.69, result);
        }

        [TestMethod]
        public void EmployeeNonA_DependentA()
        {
            var donnie = new Employee()
            {
                Name = "Donnie",
                Dependents = new List<Dependent>()
                {
                    new Dependent(){Name = "Andrew" }
                },
            };

            BenefitsCalculator sut = new BenefitsCalculator(new DebugCostService(), new DebugPayrollService());

            var result = sut.GetBenefitsCostForEmployee(donnie);

            Assert.AreEqual(55.77, result);
        }


        [TestMethod]
        public void EmployeeA_DependentNonA()
        {
            var agatha = new Employee()
            {
                Name = "Agatha",
                Dependents = new List<Dependent>()
                {
                    new Dependent(){Name = "Joan" }
                },
            };

            BenefitsCalculator sut = new BenefitsCalculator(new DebugCostService(), new DebugPayrollService());

            var result = sut.GetBenefitsCostForEmployee(agatha);

            Assert.AreEqual(53.85, result);
            //38.46 -- 34.61
            //19.23 -- 17.30
        }

        [TestMethod]
        public void EmployeeA_DependentA()
        {
            var archer = new Employee()
            {
                Name = "Archer",
                Dependents = new List<Dependent>()
                {
                    new Dependent(){Name = "Ace" }
                },
            };

            BenefitsCalculator sut = new BenefitsCalculator(new DebugCostService(), new DebugPayrollService());

            var result = sut.GetBenefitsCostForEmployee(archer);

            Assert.AreEqual(51.92, result);
        }


        [TestMethod]
        public void EmployeeNonA_MultipleDependents()
        {
            var richard = new Employee()
            {
                Name = "Richard",
                Dependents = new List<Dependent>()
{
                    new Dependent(){Name = "Tom" },
                    new Dependent(){Name = "Dick" },
                    new Dependent(){Name = "Harry" }
                },
            };

            BenefitsCalculator sut = new BenefitsCalculator(new DebugCostService(), new DebugPayrollService());

            var result = sut.GetBenefitsCostForEmployee(richard);

            Assert.AreEqual(96.15, result);
        }

        [TestMethod]
        public void EmployeeNonA_DependentsNull()
        {
            var richard = new Employee()
            {
                Name = "Richard",
                Dependents = null
            };

            BenefitsCalculator sut = new BenefitsCalculator(new DebugCostService(), new DebugPayrollService());

            var result = sut.GetBenefitsCostForEmployee(richard);

            Assert.AreEqual(38.46, result);
        }

        [TestMethod]
        public void EmployeeNameNull_NoDependents()
        {
            var TheManWithNoName = new Employee()
            {
                Name = null,
                Dependents = new List<Dependent>(),
            };

            BenefitsCalculator sut = new BenefitsCalculator(new DebugCostService(), new DebugPayrollService());

            var result = sut.GetBenefitsCostForEmployee(TheManWithNoName);

            Assert.AreEqual(38.46, result);
        }

        [TestMethod]
        public void EmployeeNameEmptyString_NoDependents()
        {
            var TheBlank = new Employee()
            {
                Name = string.Empty,
                Dependents = new List<Dependent>(),
            };

            BenefitsCalculator sut = new BenefitsCalculator(new DebugCostService(), new DebugPayrollService());

            var result = sut.GetBenefitsCostForEmployee(TheBlank);

            Assert.AreEqual(38.46, result);
        }

        [TestMethod]
        public void EmployeeName_DependentsNameNull()
        {
            var pedro = new Employee()
            {
                Name = "Pedro",
                Dependents = new List<Dependent>() 
                {
                    new Dependent(){Name = null }
                },
            };

            BenefitsCalculator sut = new BenefitsCalculator(new DebugCostService(), new DebugPayrollService());

            var result = sut.GetBenefitsCostForEmployee(pedro);

            Assert.AreEqual(57.69, result);
        }

        [TestMethod]
        public void EmployeeName_DependentsNameEmptyString()
        {
            var lorrie = new Employee()
            {
                Name = "Lorrie",
                Dependents = new List<Dependent>()
                {
                    new Dependent(){Name = string.Empty }
                },
            };

            BenefitsCalculator sut = new BenefitsCalculator(new DebugCostService(), new DebugPayrollService());

            var result = sut.GetBenefitsCostForEmployee(lorrie);

            Assert.AreEqual(57.69, result);
        }
    }
}
