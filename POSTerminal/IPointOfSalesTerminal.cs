using System.Threading.Tasks;

namespace POSTerminal
{
    public interface IPointOfSalesTerminal
    {
        Task ScanProduct(string productCode);
        double CalculateTotal();
        void StartSession();
        void EndSession();
    }
}