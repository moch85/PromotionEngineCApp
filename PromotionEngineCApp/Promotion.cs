using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngineCApp
{
    public class Promotion
    {
        public int PromotionId { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        public string ProductCode { get; set; }
        public double Price { get; set; }
    }
}
