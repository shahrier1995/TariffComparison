using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TariffComparison
{
    public class Tariff
    {
        public static void Main(string[] args)
        {
            try
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
                Tariff tariff = new Tariff();
                List<TariffModel> tariffList = new List<TariffModel>();
                tariffList.Add(new TariffModel { TariffName = "Basic electricity tariff", AnnualCost = tariff.ProductACalculation(consumption) });
                tariffList.Add(new TariffModel { TariffName = "Package tariff", AnnualCost = tariff.ProductBCalculation(consumption) });
                tariffList = tariff.GetSortedList(tariffList);
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.WriteLine("\n{0,-25} | {1,-21}", "Tariff name", "Annual costs");
                foreach (var e in tariffList)
                {
                    Console.WriteLine("{0,-25} = {1,-21}", e.TariffName, e.AnnualCost + " €/year");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured. Exception info: " + e.Message);
            }
            
        }

        public List<TariffModel> GetSortedList(List<TariffModel> list)
        {
           return list.OrderBy(i => i.AnnualCost).ToList();
        }

        public double ProductACalculation(double consumption)
        {
            double annualCost = (5 * 12) + (consumption * 0.22);
            return annualCost;
        }

        public double ProductBCalculation(double consumption)
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
