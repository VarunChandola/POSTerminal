using System.Threading.Tasks;

namespace POSTerminal
{
    public interface IPointOfSalesTerminal
    {
        Task ScanProductAsync(string productCode);
        double CalculateTotal();
    }
}