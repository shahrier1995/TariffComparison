using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TariffComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            double consumption = 0;
            bool valid = false;
            Console.Write("Enter your yearly consumption(KWh/h) :  ");
            while (!valid)
            {
                string userValue = Console.ReadLine();
                if (double.TryParse(userValue, out consumption) == false || consumption < 0)
                {
                    Console.WriteLine("Value is invalid!!");
                    Console.Write("\nPlease enter your yearly consumption(KWh/h) again: ");
                }
                else
                {
                    valid = true;
                }
            }
            List<TariffModel> tariffList = new List<TariffModel>();
            tariffList.Add(new TariffModel { TariffName = "Basic electricity tariff", AnnualCost = ProductACalculation(consumption) });
            tariffList.Add(new TariffModel { TariffName = "Package tariff", AnnualCost = ProductBCalculation(consumption) });
            tariffList = tariffList.OrderBy(i => i.AnnualCost).ToList();
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("\n{0,-25} | {1,-21}", "Tariff name", "Annual costs");
            foreach (var e in tariffList)
            {
                Console.WriteLine("{0,-25} = {1,-21}", e.TariffName, e.AnnualCost + " €/year");
            }
        }
        static double ProductACalculation(double consumption)
        {
            double annualCost = (5 * 12) + (consumption * 0.22);
            return annualCost;
        }
        static double ProductBCalculation(double consumption)
        {
            double annualCost;
            if (consumption <= 4000)
            {
                annualCost = 800;
                return annualCost;
            }
            else
            {
                annualCost = (800 + ((consumption - 4000) * .30));
                return annualCost;
            }
        }
    }
    public class TariffModel
    {
        public string TariffName { get; set; }
        public double AnnualCost { get; set; }
    }
}
