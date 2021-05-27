using System.Threading.Tasks;
using POSTerminal.DataModels;

namespace POSTerminal.Repositories
{
    /// <summary>
    /// An interface used by the PointOfSalesTerminal to retrieve product information
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Find and return a product matching the supplied product code
        /// </summary>
        /// <param name="productCode">An string that uniquely identifies a product in a repository</param>
        /// <returns>The product matching the productCode. Should return null if the product is not found.</returns>
        Task<Product> GetProductByCode(string productCode);
    }
}