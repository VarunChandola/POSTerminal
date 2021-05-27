using System.Threading.Tasks;
using POSTerminal.DataModels;

namespace POSTerminal
{
    public interface IProductRepository
    {
        Task<Product> GetProductByCode(string productCode);
    }
}