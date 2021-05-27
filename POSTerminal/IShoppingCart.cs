using System.Collections.Generic;
using POSTerminal.DataModels;

namespace POSTerminal
{
    public interface IShoppingCart
    {
        List<ProductDetails> Contents { get; }
        void Add(Product product);
    }
}