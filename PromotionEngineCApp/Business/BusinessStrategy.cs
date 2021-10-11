using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromotionEngineCApp.Interface;
using PromotionEngineCApp.Business;

namespace PromotionEngineCApp.Business
{
    class BusinessStrategy
    {
        public AppliedOffer ApplyPromotion(List<ProductCheckout> checkoutList, List<Promotion> promotions)
        {
            AppliedOffer appliedOffer = new AppliedOffer();

            //Here Strategy pattern allows a  to choose an algorithm from a family of Promotion algorithms 
            List<IBusinessStrategy> strategies = new List<IBusinessStrategy>();
            strategies.Add(new AdditionalItems());
            strategies.Add(new TwoForOne());

            try
            {
                foreach (ProductCheckout item in checkoutList)
                {
                    if (item.Quantity > 0)
                    {
                        foreach (var strategy in strategies)
                        {
                            if (strategy.CanExecute(item, promotions))
                            {
                                item.HasOffer = true;
                                item.FinalPrice = strategy.CalculateProductPrice(checkoutList);
                                appliedOffer.TotalPrice += item.FinalPrice;
                                break;
                            }
                        }
                    }
                }
                appliedOffer.Checkouts = checkoutList;
            }
            catch (Exception ex)
            {
                LogFile.LogWrite("Error in Applying Promotion in PromotionStrategy:" + ex.Message);
            }

            return appliedOffer;
        }


    }
}
