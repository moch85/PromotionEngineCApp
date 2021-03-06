using NUnit.Framework;
using PromotionEngineCApp.Interface;
using PromotionEngineCApp.Business;
using PromotionEngineCApp;
using System.Collections.Generic;


namespace PromotionEngineCApp_Test
{
    public class BusinessStrategy_Test
    {
            List<Promotion> _promotions;

            BusinessStrategy promotion;
            [SetUp]
            public void Setup()
            {
                promotion = new BusinessStrategy();
                _promotions = new List<Promotion>() { new Promotion() { Type = "Single", ProductCode = "A", Price = 130, Quantity = 3 }, new Promotion() { Type = "Single", ProductCode = "B", Price = 45, Quantity = 2 }, new Promotion() { Type = "Combo", ProductCode = "C;D", Price = 30, Quantity = 3 } };

            }

            /// <summary>
            /// Scenario A
            /// 1* A =50
            /// 1* B =30
            /// 1* C =20
            /// </summary>
            [Test]
            public void Scenario1_NoOffer()
            {
                List<ProductCheckout> orderCart = new List<ProductCheckout>() { new ProductCheckout() { ProductCode = "A", Quantity = 1, DefaultPrice = 50 }, new ProductCheckout() { ProductCode = "B", Quantity = 1, DefaultPrice = 30 }, new ProductCheckout() { ProductCode = "C", Quantity = 1, DefaultPrice = 20 } };
                double expectedValue = 100;
                double actualValue = promotion.ApplyPromotion(orderCart, _promotions).TotalPrice;
                Assert.AreEqual(expectedValue, actualValue);
            }

            /// <summary>
            /// Scenario B
            /// 5 * A =130 + 2*50
            /// 5 * B =45 + 45 + 30
            /// 1 * C =28
            //Total = 370 
            /// </summary>
            [Test]
            public void Scenario2_TwoOffer_Single()
            {
                List<ProductCheckout> orderCart = new List<ProductCheckout>() { new ProductCheckout() { ProductCode = "A", Quantity = 5, DefaultPrice = 50 }, new ProductCheckout() { ProductCode = "B", Quantity = 5, DefaultPrice = 30 }, new ProductCheckout() { ProductCode = "C", Quantity = 1, DefaultPrice = 20 } };
                double expectedValue = 370;
                double actualValue = promotion.ApplyPromotion(
                    orderCart,
                    _promotions).TotalPrice;
                Assert.AreEqual(expectedValue, actualValue);
            }

            /// <summary>
            /// Scenario C
            /// 3* A =130
            /// 5* B =45 + 45 + 1 * 30
            /// 1* C =-
            /// 1* D =30
            /// </summary>
            [Test]
            public void Scenario3_TwoOffer_Combo()
            {
                List<ProductCheckout> orderCart = new List<ProductCheckout>() { new ProductCheckout() { ProductCode = "A", Quantity = 3, DefaultPrice = 50 }, new ProductCheckout() { ProductCode = "B", Quantity = 5, DefaultPrice = 30 }, new ProductCheckout() { ProductCode = "C", Quantity = 1, DefaultPrice = 20 }, new ProductCheckout() { ProductCode = "D", Quantity = 1, DefaultPrice = 15 } };
                double expectedValue = 280;
                double actualValue = promotion.ApplyPromotion(orderCart, _promotions).TotalPrice;
                Assert.AreEqual(expectedValue, actualValue);
            }
        }
    }
}