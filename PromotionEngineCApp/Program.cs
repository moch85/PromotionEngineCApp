using System;
using System.Collections.Generic;
using PromotionEngineCApp.Interface;
using PromotionEngineCApp.Business;

namespace PromotionEngineCApp
{
    class Program
    {
        
        
        static void Main(string[] args)
        {
            IPromotionInputOutput consoleLayer = new ConsoleLayout();
            BusinessStrategy promotion = new BusinessStrategy();
            List<ProductCheckout> checkoutList = new List<ProductCheckout>();
            AppliedOffer appliedOffer = new AppliedOffer();

            IConfigData configManagement = new ConfigData(); ;

            try
            {
                LogFile.LogWrite("Promotion Engine is initialized : ");


                try
                {
                    checkoutList = consoleLayer.LoadUserInput();
                }
                catch (Exception ex)
                {
                    LogFile.LogWrite("Error in Checking out Products :" + ex.Message);
                }

                try
                {
                    appliedOffer = promotion.ApplyPromotion(checkoutList, configManagement.GetProductOffers()); ;
                }
                catch (Exception ex)
                {
                    LogFile.LogWrite("Error in  Applying Promotio :" + ex.Message);
                }

                try
                {
                    if (appliedOffer.Checkouts != null)
                    {
                        consoleLayer.DisplayTotalPrice(appliedOffer);
                    }
                }
                catch (Exception ex)
                {
                    LogFile.LogWrite("Error in  Displaying TotalPrice:" + ex.Message);
                }

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                LogFile.LogWrite("Exception in Promotion Engine .... : " + ex.Message);
            }
        }

       
    }
}
