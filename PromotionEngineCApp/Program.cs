using System;
using System.Collections.Generic;

namespace PromotionEngineCApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            ConsoleLayout.WriteLine("total number of order");
            int a = Convert.ToInt32(ConsoleLayout.ReadLine());
            for (int i = 0; i < a; i++)
            {
                ConsoleLayout.WriteLine("enter the type of product:A,B,C or D");
                string type = ConsoleLayout.ReadLine();
                Product p = new Product();
                products.Add(p);
            }

            int totalPrice = GetTotalPrice(products);
            ConsoleLayout.WriteLine(totalPrice);
            ConsoleLayout.ReadLine();
        }

        private static int GetTotalPrice(List<Product> products)
        {
            int counterofA = 0;
            int priceofA = 50;
            int counterofB = 0;
            int priceofB = 30;
            int CounterofC = 0;
            int priceofC = 20;
            int CounterofD = 0;
            int priceofD = 15;
            foreach (Product pr in products)
            {
                if (pr.ProductCode == "A" || pr.ProductName == "a")
                {
                    counterofA = counterofA + 1;
                }
                if (pr.ProductCode == "B" || pr.ProductName == "b")
                {
                    counterofB = counterofB + 1;
                }
                if (pr.ProductCode == "C" || pr.ProductName == "c")
                {
                    CounterofC = CounterofC + 1;
                }
                if (pr.ProductCode == "D" || pr.ProductName == "d")
                {
                    CounterofD = CounterofD + 1;
                }
            }
            int totalPriceofA = (counterofA / 3) * 130 + (counterofA % 3 * priceofA);
            int totalPriceofB = (counterofB / 2) * 45 + (counterofB % 2 * priceofB);
            int totalPriceofC = (CounterofC * priceofC);
            int totalPriceofD = (CounterofD * priceofD);
            return totalPriceofA + totalPriceofB + totalPriceofC + totalPriceofD;

        }
    }
}
