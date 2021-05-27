using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POSTerminal.DataModels;

namespace POSTerminal
{
    public class PointOfSalesTerminal : IPointOfSalesTerminal
    {
        private readonly Dictionary<string, ScannedProductDetails> _scannedItems = new();
        private readonly IProductRepository _itemRepository;

        public PointOfSalesTerminal(IProductRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task ScanProduct(string productCode)
        {
            var item = await _itemRepository.GetProductByCode(productCode);
            if (item == null)
            {
                throw new ProductNotFoundException(productCode);
            }

            if (!_scannedItems.TryGetValue(productCode, out ScannedProductDetails? itemDetails))
            {
                itemDetails = new ScannedProductDetails {Product = item};
                _scannedItems[productCode] = itemDetails;
            }

            itemDetails.Qty += 1;
        }

        public double CalculateTotal()
        {
            return PriceCalculator.CalculatePrice(_scannedItems.Values.ToList());
        }

        public void StartSession()
        {
            _scannedItems.Clear();
        }

        public void EndSession()
        {
            _scannedItems.Clear();
        }
    }

    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string productCode) : base($"Product with code {productCode} does not exist")
        {
        }
    }
}