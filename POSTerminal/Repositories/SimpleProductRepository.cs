using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POSTerminal.DataModels;
using POSTerminal.Extensions;

namespace POSTerminal.Repositories
{
    public class SimpleProductRepository : IProductRepository
    {
        private Dictionary<string, Product> _products;

        public SimpleProductRepository(List<Product> products)
        {
            _products = products.ToDictionary(product => product.Code);
        }
        
        public Task<Product> GetProductByCode(string productCode)
        {
            return Task.FromResult(_products.GetValueOrDefault(productCode));
        }
    }
}

