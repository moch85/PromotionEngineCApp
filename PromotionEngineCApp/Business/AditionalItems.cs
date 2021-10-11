using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromotionEngineCApp.Interface;

namespace PromotionEngineCApp.Business
{
    public class AdditionalItems : IBusinessStrategy
    {
        private Promotion appliedPromotion;
        private ProductCheckout ProductCheckout;

        public AdditionalItems()
        {
            appliedPromotion = new Promotion();
            ProductCheckout = new ProductCheckout();
        }

        public bool CanExecute(ProductCheckout product, List<Promotion> promotions)
        {
            ProductCheckout = product;
            appliedPromotion = promotions.Where(x => x.ProductCode == product.ProductCode).FirstOrDefault();
            if (appliedPromotion != null && appliedPromotion.Type == PromotionTypeConstants.Single)
            {
                product.IsValidated = true;
                return true;
            }

            return false;
        }

        public double CalculateProductPrice(List<ProductCheckout> productCheckoutList)
        {
            double finalPrice = 0;
            try
            {
                int totalEligibleItems = ProductCheckout.Quantity / appliedPromotion.Quantity;
                int remainingItems = ProductCheckout.Quantity % appliedPromotion.Quantity;
                finalPrice = appliedPromotion.Price * totalEligibleItems + remainingItems * (ProductCheckout.DefaultPrice);

            }
            catch (ArithmeticException ex)
            {
                LogFile.LogWrite("Error in AdditionalItems :" + ex.Message);
            }
            catch (Exception e)
            {
                LogFile.LogWrite("Error in AdditionalItems :" + e.Message);
            }

            return finalPrice;
        }
    }
}


