using System;
using System.Collections.Generic;
using POSTerminal.DataModels;

namespace POSTerminal
{
    public static class PriceCalculator
    {
        public static double CalculatePrice(List<ProductDetails> products)
        {
            double total = 0;
            foreach (var productDetails in products)
            {
                Product product = productDetails.Product;
                var bulkPricing = product.BulkPricing;
                if (bulkPricing != null)
                {
                    var batchCount = Math.DivRem(productDetails.Qty, bulkPricing.Qty, out var remainingUnits);
                    total += batchCount * bulkPricing.Price + remainingUnits * product.UnitPrice;
                }
                else
                {
                    total += productDetails.Qty * product.UnitPrice;
                }
            }

            return total;
        }
    }
}