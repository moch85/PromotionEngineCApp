using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngineCApp.Interface
{
   
        public interface IPromotionInputOutput
        {
           
            List<ProductCheckout> LoadUserInput();

            bool DisplayTotalPrice(AppliedOffer appliedOffer);
        }
    }

