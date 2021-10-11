using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngineCApp
{
    public class AppliedOffer
    {
        public List<ProductCheckout> Checkouts { get; set; }
        public double TotalPrice { get; set; }
    }
}
