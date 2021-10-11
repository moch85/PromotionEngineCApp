using System.Collections.Generic;


namespace PromotionEngineCApp.Interface
{
    public interface IConfigData
    {
        List<Product> GetAvilableProducts();

        List<Promotion> GetProductOffers();
    }
}

