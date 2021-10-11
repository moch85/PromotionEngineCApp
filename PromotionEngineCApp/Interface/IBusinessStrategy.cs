using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngineCApp.Interface
{
    public interface IBusinessStrategy
    {
        /// <summary>
        /// Can Execute
        /// </summary>
        /// <param name="product"></param>
        /// <param name="promotions"></param>
        /// <returns></returns>
        bool CanExecute(ProductCheckout product, List<Promotion> promotions);

        /// <summary>
        /// Calculate ProductPrice
        /// </summary>
        /// <param name="productCheckoutList"></param>
        /// <returns></returns>
        double CalculateProductPrice(List<ProductCheckout> productCheckoutList);
    }

}
