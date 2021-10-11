using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromotionEngineCApp.Interface;

namespace PromotionEngineCApp.Business
{
    public class TwoForOne : IBusinessStrategy
    {
        Promotion appliedPromotion;
        ProductCheckout recentProductCheckout;
        List<ProductCheckout> productCheckouts;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productCheckout"></param>
        /// <param name="promotions"></param>
        /// <returns></returns>
        public bool CanExecute(ProductCheckout productCheckout, List<Promotion> promotions)
        {
            recentProductCheckout = productCheckout;
            appliedPromotion = promotions.Where(x => x.ProductCode.Split(';').Contains(productCheckout.ProductCode)).FirstOrDefault();
            if (appliedPromotion != null && !productCheckout.IsValidated && appliedPromotion.Type == PromotionTypeConstants.Combo)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="productCheckoutList"></param>
        /// <returns></returns>
        public double CalculateProductPrice(List<ProductCheckout> productCheckoutList)
        {
            productCheckouts = new List<ProductCheckout>();

            double finalPrice = 0;


            try
            {
                string[] str = appliedPromotion.ProductCode.Split(';').ToArray();
                foreach (ProductCheckout item in productCheckoutList)
                {
                    if (str.Contains(item.ProductCode))
                    {
                        productCheckouts.Add(item);
                        item.IsValidated = true;
                    }
                }

                int quantity_first = 0;
                int quantity_second = 0;
                if (productCheckouts.Count > 1)
                {
                    quantity_first = productCheckouts[0].Quantity;
                    quantity_second = productCheckouts[1].Quantity;
                }
                //if one of the product quatity is empty
                if (quantity_first == 0 || quantity_second == 0)
                {
                    return recentProductCheckout.DefaultPrice;

                }

                //if both of the products are equal is size
                if (quantity_first == quantity_second)
                {
                    finalPrice = appliedPromotion.Price * quantity_first;
                }
                else if (quantity_first > quantity_second)
                {
                    int additionalItems = quantity_first - quantity_second;
                    finalPrice = (recentProductCheckout.DefaultPrice * additionalItems) + (appliedPromotion.Price * quantity_second);
                }
                else if (quantity_first < quantity_second)
                {
                    int additionalItems = quantity_second - quantity_first;
                    finalPrice = (recentProductCheckout.DefaultPrice * additionalItems) + (appliedPromotion.Price * quantity_first);
                }
            }
            catch (ArithmeticException ex)
            {
                LogFile.LogWrite("Error in TwoForOne :" + ex.Message);
            }
            catch (Exception e)
            {
                LogFile.LogWrite("Error in TwoForOne :" + e.Message);
            }

            return finalPrice;
        }


    }
}
