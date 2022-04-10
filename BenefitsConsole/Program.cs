using BenefitsCalculator.Interfaces;
using BenefitsCalculator.Model;
using System;
using System.Collections.Generic;

namespace BenefitsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IPayrollService payrollService = new BenefitsCalculator.Services.Debug.DebugPayrollService();
            IBenefitCostService benefitsCostService = new BenefitsCalculator.Services.Debug.DebugCostService();
            var calc = new BenefitsCalculator.BenefitsCalculator(benefitsCostService, payrollService);

            Console.WriteLine("Welcome to the Benefits Console.");
            Console.WriteLine("Here you can determine the your cost of benefits.");

            Console.WriteLine("What is your name?");
            string userName = DisplayIndentedRequestForInput();

            Employee employee = new Employee() { Name = userName, Dependents = new List<Dependent>() };

            Console.WriteLine($"It is nice to meet you, {employee.Name}.");

            int dependentCountAsInt = -1;
            while (dependentCountAsInt < 0)
            {
                Console.WriteLine($"How many dependents to you have?");
                string dependentCountAsString = DisplayIndentedRequestForInput();

                try
                {
                    var candidate = Int32.Parse(dependentCountAsString);
                    if (dependentCountAsInt < candidate)
                    {
                        dependentCountAsInt = candidate;
                    }
                    else 
                    {
                        Console.WriteLine($"Sorry, but you cannot have a negative number of dependents.");
                    }
                }
                catch
                {
                    Console.WriteLine($"Sorry, but I didn't understand that input.");
                }
            }

            if (dependentCountAsInt > 0) 
            {
                Console.WriteLine($"I will need to know the names of your dependents.");

                int index = 1;

                while (index <= dependentCountAsInt)
                {
                    Console.WriteLine($"Please enter the name of dependent #{index}.");
                    string dependentName = DisplayIndentedRequestForInput();

                    employee.Dependents.Add(new Dependent() { Name = dependentName });

                    index++;
                }


            }

            var result = calc.GetBenefitsCostForEmployee(employee);

            Console.WriteLine($"Your benefits cost will be ${result} per pay period.");
            Console.WriteLine($"Have a nice day.");
            Console.ReadLine();

        }


        private static string DisplayIndentedRequestForInput() 
        {
            Console.Write($" >> ");
            return Console.ReadLine();
        }
    }
}
