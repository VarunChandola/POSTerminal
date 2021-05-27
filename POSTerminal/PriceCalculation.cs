using System;
using System.Collections.Generic;
using POSTerminal.DataModels;

namespace POSTerminal
{
    public class PriceCalculator
    {
        public static double CalculatePrice(List<ScannedProductDetails> scannedProducts)
        {
            double total = 0;
            foreach (var item in scannedProducts)
            {
                var product = item.Product;
                var bulkPricing = product.BulkPricing;

                if (bulkPricing != null)
                {
                    var batchCount = Math.DivRem(item.Qty, bulkPricing.Qty, out int remainingUnits);
                    total += batchCount * bulkPricing.Price + remainingUnits * product.UnitPrice;
                }
                else
                {
                    total += item.Qty * product.UnitPrice;
                }
            }

            return total;
        }
    }
}