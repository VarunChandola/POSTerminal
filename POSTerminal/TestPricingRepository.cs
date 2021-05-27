using System.Collections.Generic;
using System.Threading.Tasks;
using POSTerminal.DataModels;

namespace POSTerminal
{
    public class TestPricingRepository : IProductRepository
    {
        private readonly Dictionary<string, Product> _pricing = new()
        {
            {"A", new Product(UnitPrice:1.25, new BulkPricing(Qty:3, Price:3))},
            {"B", new Product(UnitPrice: 4.25)},
            {"C", new Product(UnitPrice: 1, new BulkPricing(Qty: 6, Price: 5))},
            {"D", new Product(UnitPrice: .75)}
        };

        public Task<Product> GetProductByCode(string productCode)
        {
            return Task.FromResult(_pricing[productCode]);
        }
    }
}