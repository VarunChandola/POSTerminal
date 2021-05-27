using System;

namespace POSTerminal.Exceptions
{
    /// <summary>
    /// The product matching the product code was not found
    /// </summary>
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string productCode) : base($"Product with code {productCode} does not exist")
        {
        }
    }
}