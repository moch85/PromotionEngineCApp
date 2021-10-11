
using PromotionEngineCApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngineCApp
{
    public class ConsoleLayout : IPromotionInputOutput
    {
        ConfigData configManagement;

       
        public ConsoleLayout()
        {
            configManagement = new ConfigData();
        }

        public List<ProductCheckout> LoadUserInput()
        {
            List<ProductCheckout> checkoutList = new List<ProductCheckout>();
            List<Product> lstProduct = LoadAvilableProducts();

            Console.WriteLine("Enter Inputs");
            try
            {

                foreach (var item in lstProduct)
                {
                    Console.WriteLine("Quantity of " + item.ProductCode);
                    int quantity = Convert.ToInt32(Console.ReadLine());

                    checkoutList.Add(new ProductCheckout()
                    {
                        ProductCode = item.ProductCode,
                        Quantity = quantity,
                        DefaultPrice = item.Price
                    });
                }

            }
            catch (FormatException ex)
            {

                Console.WriteLine("Error in User Entry: " + ex.Message);
            }
            catch (OverflowException ex)
            {

                Console.WriteLine("Error in User Entry: " + ex.Message);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error in User Entry: " + ex.Message);
            }


            return checkoutList;
        }

     
        private List<Product> LoadAvilableProducts()
        {
            return configManagement.GetAvilableProducts();
        }
        public bool DisplayTotalPrice(AppliedOffer appliedOffer)
        {
            Console.WriteLine("Calculating Price...");
            Console.WriteLine("");
            foreach (var item in appliedOffer.Checkouts)
            {
                Console.WriteLine(item.ProductCode + " - " + item.Quantity + " - " + item.FinalPrice);
            }
            Console.WriteLine("Total Price: " + appliedOffer.TotalPrice);
            return true;
        }
    }
}
