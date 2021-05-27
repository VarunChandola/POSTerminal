using System.Threading.Tasks;
using POSTerminal.DataModels;
using POSTerminal.Exceptions;
using POSTerminal.Repositories;

namespace POSTerminal
{
    public class PointOfSalesTerminal : IPointOfSalesTerminal
    {
        private readonly ShoppingCart _cart = new();
        private readonly IProductRepository _itemRepository;

        public PointOfSalesTerminal(IProductRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task ScanProductAsync(string productCode)
        {
            Product product = await _itemRepository.GetProductByCode(productCode) ??
                              throw new ProductNotFoundException(productCode);
            _cart.Add(product);
        }

        public double CalculateTotal()
        {
            return PriceCalculator.CalculatePrice(_cart.Contents);
        }
    }
}