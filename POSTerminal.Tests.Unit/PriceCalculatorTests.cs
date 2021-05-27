using System.Collections.Generic;
using NUnit.Framework;
using POSTerminal;
using POSTerminal.DataModels;

namespace POSTerminalTests
{
    public class PriceCalculatorTests
    {
        [Test]
        public void CalculatePrice_WithProducts_ReturnsExpectedPrice()
        {
            const int expectedCalculatedPrice = 31;
            
            var productA = new Product("A", 1.25, new BulkPricing(3, 3));
            var productB = new Product("B", 4.25);
            var productC = new Product("C", 1, new BulkPricing(6, 5));
            var productD = new Product("D", 0.75);

            var productDetails = new List<ProductDetails>
            {
                new(productA, 4),
                new(productB, 5),
                new(productD, 6),
                new(productC, 1)
            };

            var calculatedPrice = PriceCalculator.CalculatePrice(productDetails);

            Assert.That(calculatedPrice, Is.EqualTo(expectedCalculatedPrice));
        }

        [Test]
        public void CalculatePrice_WithEmptyProductDetails_ReturnsZero()
        {
            var calculatedPrice = PriceCalculator.CalculatePrice(new List<ProductDetails>());

            Assert.That(calculatedPrice, Is.Zero);
        }
    }
}