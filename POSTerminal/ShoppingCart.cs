using System.Collections.Generic;
using System.Linq;
using POSTerminal.DataModels;

namespace POSTerminal
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly Dictionary<Product, int> _contents = new();

        public List<ProductDetails> Contents =>
            _contents.Select(entry => new ProductDetails(entry.Key, entry.Value)).ToList();

        public void Add(Product product)
        {
            _contents.TryGetValue(product, out var qty);
            _contents[product] = qty + 1;
        }
    }
}